using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrobalHook;

namespace ScreenCaptureWinFormCSharp
{
    /// <summary>
    /// MainFormのロジック
    /// </summary>
    public partial class FormMain : Form
    {
        private Point m_mousePoint;
        private static IntPtr m_hHook = IntPtr.Zero;
        MouseHook.HookProcedureDelegate m_proc;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            lblTitle.MouseDown += new MouseEventHandler(OnMouseDownLblTitle);
            lblTitle.MouseMove += new MouseEventHandler(OnMouseMoveLblTitle);

            if (m_hHook == IntPtr.Zero)
            {
                m_proc = new MouseHook.HookProcedureDelegate(MouseHookProc);
                SetMouseHook(m_proc);
            }
            else
            {
                RemoveMouseHook();
            }
        }

        /// <summary>
        /// タイトルバーマウスダウンのクリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベントのデータ</param>
        private void OnMouseDownLblTitle(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                m_mousePoint = new Point(e.X, e.Y);
            }

            return;
        }

        /// <summary>
        /// タイトルバーマウスムーブのクリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベントのデータ</param>
        private void OnMouseMoveLblTitle(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - m_mousePoint.X;
                this.Top += e.Y - m_mousePoint.Y;
            }

            return;
        }

        /// <summary>
        /// マウスフックの設定
        /// </summary>
        /// <param name="_proc">マウスフックのデリゲート</param>
        /// <returns>マウスフックの設定結果 成功/失敗</returns>
        private bool SetMouseHook(MouseHook.HookProcedureDelegate _proc)
        {
            bool bResult = true;

            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule processModule = process.MainModule)
            {
                m_hHook = MouseHook.SetWindowsHookEx(MouseHook.WH_MOUSE_LL, _proc, MouseHook.GetModuleHandle(processModule.ModuleName), 0);
                if (m_hHook == IntPtr.Zero)
                {
                    {
                        MessageBox.Show("SetWindowsHookEx Failed.");
                        bResult = false;
                    }
                }
            }

            return bResult;
        }

        /// <summary>
        /// マウスフックの削除
        /// </summary>
        private void RemoveMouseHook()
        {
            if (MouseHook.UnhookWindowsHookEx(m_hHook) == false)
            {
                MessageBox.Show("UnhookWindowsHookEx Failed.");
            }

            return;
        }

        /// <summary>
        /// マウスフックの削除
        /// </summary>
        /// <param name="_nCode">現在のフックプロシージャに渡されたnCode</param>
        /// <param name="_wParam">現在のフックプロシージャに渡されたwParam</param>
        /// <param name="_lParam">現在のフックプロシージャに渡されたlParam</param>
        /// <returns>フックチェーン内の次のフックプロシージャの戻り値</returns>
        private IntPtr MouseHookProc(int _nCode, IntPtr _wParam, IntPtr _lParam)
        {
            if (_nCode >= 0)
            {
                MouseHook.MouseHookStruct mouseHookStruct = (MouseHook.MouseHookStruct)Marshal.PtrToStructure(_lParam, typeof(MouseHook.MouseHookStruct));
                if (mouseHookStruct != null)
                {
                    String strText = "Screen Capture" + "  x = " + mouseHookStruct.pt.x.ToString("d") + " : y = " + mouseHookStruct.pt.y.ToString("d");
                    lblTitle.Text = strText;

                    Bitmap bitmap = new Bitmap(400, 400);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.CopyFromScreen(mouseHookStruct.pt.x - 200, mouseHookStruct.pt.y - 200, 0, 0, bitmap.Size);
                    graphics.Dispose();

                    pictureBox.Image = bitmap;
                    pictureBox.Refresh();
                }
            }

            return MouseHook.CallNextHookEx(m_hHook, _nCode, _wParam, _lParam);
        }

        /// <summary>
        /// 閉じるボタンのクリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">キー入力イベントのデータ</param>
        private void OnClickBtnClose(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Close the application ?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
            {
                this.Close();
            }

            return;
        }

        /// <summary>
        /// 最小ボタンのクリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">キー入力イベントのデータ</param>
        private void OnClickBtnMinimizedIcon(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            return;
        }
    }
}