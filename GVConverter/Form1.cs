using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GVConverter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //設定読み込み処理
            tbxConverterPath.Text = Properties.Settings.Default.converterPath;
            cbLayoutEngine.Text = Properties.Settings.Default.layoutEngine;
            cbOutputFormat.Text = Properties.Settings.Default.outputFormat;
        }

        //アイテムドロップ時マウスポインタ変更
        private void lbInputFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //アイテムドロップ処理
        private void lbInputFiles_DragDrop(object sender, DragEventArgs e)
        {
            // ファイルが渡されていなければ、何もしない
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            // 渡されたファイルに対して処理を行う
            foreach (var filePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                //ディレクトリと重複しているアイテムは除外
                if ((File.Exists(filePath)) && (lbInputFiles.FindStringExact(filePath) == ListBox.NoMatches))
                {
                    lbInputFiles.Items.Add(filePath);
                }
            }
        }

        //選択アイテムをリストから削除
        private void tsmiDeleteSelected_Click(object sender, EventArgs e)
        {
            if (lbInputFiles.SelectedItems.Count > 0)
            {
                while (lbInputFiles.SelectedIndex > -1)
                {
                    lbInputFiles.Items.RemoveAt(lbInputFiles.SelectedIndex);
                }
            }
        }

        //リストをクリア
        private void btnClear_Click(object sender, EventArgs e)
        {
            lbInputFiles.Items.Clear();
        }

        //選択状態によって削除ボタンの有効状態切り替え
        private void cmsInputFiles_Opening(object sender, CancelEventArgs e)
        {
            if (lbInputFiles.SelectedItems.Count > 0)
            {
                tsmiDeleteSelected.Enabled = true;
            }
            else
            {
                tsmiDeleteSelected.Enabled = false;
            }
        }

        //Graphviz実行ファイル(dot.exe)選択ダイアログ表示
        private void btnOpenConverterSelectDialog_Click(object sender, EventArgs e)
        {
            if (ofdConverterSelectDialog.ShowDialog() == DialogResult.OK)
            {
                tbxConverterPath.Text = ofdConverterSelectDialog.FileName;
            }
        }

        //変換処理実行開始
        private void btnConvert_Click(object sender, EventArgs e)
        {
            //Graphviz実行ファイルが存在するか確認
            string converterPath = tbxConverterPath.Text;
            if (!File.Exists(converterPath))
            {
                MessageBox.Show("Graphviz実行ファイルパスが不正です");
                return;
            }

            //リストにアイテムが存在するか確認
            if (lbInputFiles.Items.Count > 0)
            {
                //変換開始ボタンを無効化
                btnConvert.Enabled = false;

                //変換実行
                DoConvertAsync(converterPath);

                //変換開始ボタンを有効化
                btnConvert.Enabled = true;
            }
        }

        //変換処理実行
        private async void DoConvertAsync(string converterPath)
        {
            //ProgressBarを設定
            pbConvertProgress.Maximum = lbInputFiles.Items.Count;
            pbConvertProgress.Value = 0;


            for (int i = 0; i < lbInputFiles.Items.Count; i++)
            {
                pbConvertProgress.Value = i + 1;
                try
                {
                    //引数生成
                    string outpath = Path.Combine(Path.GetDirectoryName(lbInputFiles.Items[i].ToString()), Path.GetFileNameWithoutExtension(lbInputFiles.Items[i].ToString()) + "." + cbOutputFormat.Text);
                    string argstr = string.Format("-K {0} -T {1} \"{2}\" -o \"{3}\"", cbLayoutEngine.Text, cbOutputFormat.Text, lbInputFiles.Items[i], outpath);

                    //実行
                    await Task.Run(() =>
                    {
                        ProcessStartInfo procinfo = new ProcessStartInfo();
                        procinfo.FileName = converterPath;
                        procinfo.Arguments = argstr;
                        procinfo.UseShellExecute = false;
                        procinfo.ErrorDialog = false;
                        procinfo.CreateNoWindow = true;

                        Process proc = Process.Start(procinfo);
                        proc.WaitForExit();
                        proc.Dispose();
                    });
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            //ProgressBar初期化
            pbConvertProgress.Value = 0;
        }

        //フォームを閉じる前に設定を保存
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.converterPath = tbxConverterPath.Text;
            Properties.Settings.Default.layoutEngine = cbLayoutEngine.Text;
            Properties.Settings.Default.outputFormat = cbOutputFormat.Text;
            Properties.Settings.Default.Save();
        }
    }
}
