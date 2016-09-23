using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GVConverter
{
    public partial class frmMain : Form
    {
        bool isWorking = false;
        bool cancelRequest = false;

        public frmMain()
        {
            InitializeComponent();

            //設定読み込み処理
            tbxConverterPath.Text = Properties.Settings.Default.converterPath;
            cbLayoutEngine.Text = Properties.Settings.Default.layoutEngine;
            cbOutputFormat.Text = Properties.Settings.Default.outputFormat;
            cbxAddDotFileOnly.Checked = Properties.Settings.Default.addDotFileOnly;
            cbxAddRecursively.Checked = Properties.Settings.Default.addRecursively;
            cbxExcludeDuplicate.Checked = Properties.Settings.Default.excludeDuplicate;
        }

        //アイテムドロップ時マウスポインタ変更
        private void lbInputFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //ファイル・フォルダ以外がドロップされようとしているので禁止アイコンに変更
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.All;
            }
        }

        //アイテムドロップ処理
        private void lbInputFiles_DragDrop(object sender, DragEventArgs e)
        {
            // ファイルまたはディレクトリが渡されていなければ、何もしない
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            //lbInputFilesの描画を一時停止
            lbInputFiles.BeginUpdate();

            // 再帰的に全ファイルを処理
            if (cbxAddRecursively.Checked)
            {
                // 再帰的に全ファイルを取得
                var allFiles = getAllFiles((string[])e.Data.GetData(DataFormats.FileDrop));

                // 渡されたファイルに対して処理を行う
                foreach (var filePath in allFiles)
                {
                    //指定されていればdotファイル以外であればスキップ
                    if ((cbxAddDotFileOnly.Checked) && (Path.GetExtension(filePath) != ".dot")) continue;

                    //指定されていれば出力先に重複するファイルが存在していればスキップ
                    if (cbxExcludeDuplicate.Checked)
                    {
                        if (File.Exists(Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "." + cbOutputFormat.Text))) continue;
                    }

                    //lbInputFiles内の重複しているアイテムとディレクトリは除外しながらlbInputFilesに追加
                    if ((File.Exists(filePath)) && (lbInputFiles.FindStringExact(filePath) == ListBox.NoMatches))
                    {
                        lbInputFiles.Items.Add(filePath);
                    }
                }
            }

            // ドロップされたアイテムのみ処理
            else
            {
                // 渡されたファイルに対して処理を行う
                foreach (var filePath in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    //指定されていればdotファイル以外であればスキップ
                    if ((cbxAddDotFileOnly.Checked) && (Path.GetExtension(filePath) != ".dot")) continue;

                    //指定されていれば出力先に重複するファイルが存在していればスキップ
                    if (cbxExcludeDuplicate.Checked)
                    {
                        if (File.Exists(Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "." + cbOutputFormat.Text))) continue;
                    }

                    //lbInputFiles内の重複しているアイテムとディレクトリは除外しながらlbInputFilesに追加
                    if ((File.Exists(filePath)) && (lbInputFiles.FindStringExact(filePath) == ListBox.NoMatches))
                    {
                        lbInputFiles.Items.Add(filePath);
                    }
                }
            }

            //lbInputFilesの描画を再開
            lbInputFiles.EndUpdate();
        }

        private static IEnumerable<string> getAllFiles(IEnumerable<string> paths)
        {
            var list = new List<string>();
            foreach (var path in paths)
            {
                if (File.Exists(path))
                    list.Add(path);
                else if (Directory.Exists(path))
                    list.AddRange(getChildFiles(path));
            }
            return list;
        }

        private static IEnumerable<string> getChildFiles(string folderPath)
        {
            var folder = new System.IO.DirectoryInfo(folderPath);
            var list = new List<string>();
            foreach (var subFolder in folder.GetDirectories())
                list.AddRange(getChildFiles(subFolder.FullName));
            foreach (var file in folder.GetFiles())
                list.Add(file.FullName);
            return list;
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


        //変換処理実行開始・キャンセルボタン処理
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (isWorking)
            {
                cancelRequest = true;
                btnConvert.Enabled = false;
            }
            else
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
                    //変換実行
                    DoConvertAsync(converterPath);
                }
            }

        }

        //変換処理実行
        private async void DoConvertAsync(string converterPath)
        {
            //ユーザ入力コントロールを無効化
            btnClear.Enabled = false;
            btnOpenConverterSelectDialog.Enabled = false;
            tbxConverterPath.Enabled = false;
            cbLayoutEngine.Enabled = false;
            cbOutputFormat.Enabled = false;
            cmsInputFiles.Enabled = false;

            //変換開始ボタンの表示切替
            btnConvert.Text = "キャンセル";
            isWorking = true;
            cancelRequest = false;

            //ProgressBarを設定
            pbConvertProgress.Maximum = lbInputFiles.Items.Count;
            pbConvertProgress.Value = 0;

            //リスト内の全てのファイルを処理
            for (int i = 0; i < lbInputFiles.Items.Count; i++)
            {
                if (cancelRequest == true)
                {
                    break;
                }

                pbConvertProgress.Value = i + 1;
                try
                {
                    //引数生成
                    string outpath = Path.Combine(Path.GetDirectoryName(lbInputFiles.Items[i].ToString()), Path.GetFileNameWithoutExtension(lbInputFiles.Items[i].ToString()) + "." + cbOutputFormat.Text);
                    string argstr = $"-K {cbLayoutEngine.Text} -T {cbOutputFormat.Text} \"{lbInputFiles.Items[i]}\" -o \"{outpath}\"";

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
                    break;
                }
            }

            isWorking = false;
            cancelRequest = false;

            //ProgressBar初期化
            pbConvertProgress.Value = 0;

            //変換開始ボタンの表示切替
            btnConvert.Text = "変換実行";
            btnConvert.Enabled = true;
            btnClear.Enabled = true;
            btnOpenConverterSelectDialog.Enabled = true;
            tbxConverterPath.Enabled = true;
            cbLayoutEngine.Enabled = true;
            cbOutputFormat.Enabled = true;
            cmsInputFiles.Enabled = true;
        }

        //フォームを閉じる前に設定を保存
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.converterPath = tbxConverterPath.Text;
            Properties.Settings.Default.layoutEngine = cbLayoutEngine.Text;
            Properties.Settings.Default.outputFormat = cbOutputFormat.Text;
            Properties.Settings.Default.addDotFileOnly = cbxAddDotFileOnly.Checked;
            Properties.Settings.Default.addRecursively = cbxAddRecursively.Checked;
            Properties.Settings.Default.excludeDuplicate = cbxExcludeDuplicate.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
