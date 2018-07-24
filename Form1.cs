using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreTweet;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.IO;
using Twitter.Properties;

namespace Twitter
{
    public partial class Form1 : Form
    {

        /*
         * Api_KeyとApi_Secretについては値を設定して利用すること
         */
        const string Api_Key = "";
        const string Api_Secret = "";
        UserModel model = null;

        public Form1()
        {
            InitializeComponent();
            this.model = Settings.Default.Lines;
        }

        /// <summary>
        /// 入力された内容をツイートする
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.model.tokens.ForEach( token => token.Statuses.Update(new { status = textBox1.Text }));
            }
            catch (Exception ex)
            {
                textBox2.Text = ex.Message;
            }
        }

        /// <summary>
        /// Twitter連携を行う
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var session = OAuth.Authorize(Api_Key, Api_Secret);

                Process.Start(session.AuthorizeUri.AbsoluteUri);

                var pinCode = Interaction.InputBox("アプリ認証後に表示されるPINCodeを入力");

                this.model.tokens.Add(OAuth.GetTokens(session, pinCode));
            }
            catch (Exception ex)
            {
                textBox2.Text = ex.Message;
            }
        }
    }
}
