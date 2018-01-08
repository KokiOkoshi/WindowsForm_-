using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_練習用
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataInitialize();
            ApplicationInitialize();
        }

        /// <summary>
        /// データの初期化処理
        /// </summary>
        static void DataInitialize()
        {

        }

        /// <summary>
        /// Application規定の初期化処理
        /// </summary>
        static void ApplicationInitialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


    }
}
