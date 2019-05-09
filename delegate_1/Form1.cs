using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delegate_1
{
    public partial class Form1 : Form
    {

        Class1 class1 = new Class1();

        public Form1()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 借錢動作
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="customAct"></param>
        private void LendAction(string amount, Func<string, string> customAct)
        {
            txt_result.Text = string.Empty;

            //決定要借出的金額
            string finalAmount;

            //我們不需要知道這個customAct到底是什麼
            //反正他跑完會回傳一個我們要的東西就對了
            //在這裡回傳的就是最終借出金額
            finalAmount = customAct(amount);

            string commonRes;
            if (!string.IsNullOrEmpty(finalAmount))
            {
                commonRes = string.Format("借出{0}元", finalAmount);
            }
            else
            {
                commonRes = "掉頭就走";
            }

            txt_result.Text += commonRes;
        }

        /// <summary>
        /// 借錢給正妹的自訂動作
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private string LendToGirl(string amount, Func<string, string> customAct)
        {
            //自訂動作：跟正妹狂聊，最後決定借五百萬
            var res =
    @"詢問正妹：真的只要借{0}嗎?夠不夠啊?
詢問正妹：要幫妳買點數卡嗎?
詢問正妹：可以加妳的Line嗎?
詢問正妹：妳幾歲呀?
詢問正妹：妳住哪?
詢問正妹：妳有男朋友嗎?
詢問正妹：妳三圍多少?
詢問正妹：禮拜六有空嗎?
...
.....
....
哇!服務這麼好喔!
....
.....
GGInInDer
OK~{1}沒問題!
....
...去提款機領{1}元
";
            var finalAmount = "五百萬";
            txt_result.Text = string.Format(res, amount, finalAmount);

            //回傳最後決定的金額
            return finalAmount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LendAction("10", class1.CustomAction);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LendToGirl("30萬", class1.CustomAction);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
