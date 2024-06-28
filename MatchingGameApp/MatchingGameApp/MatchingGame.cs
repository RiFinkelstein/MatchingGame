﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGameApp
{
    public partial class MatchingGame : Form
    {
        Button MatchPart1;
        Button MatchPart2;

        Button ClickedButton1;
        Button ClickedButton2;

        List<Button> lstMatchButtons1;
        List<Button> lstMatchButtons2;
        List<string> lstMatchStrings;



        public MatchingGame()
        {
            InitializeComponent();
            btnStart.Click += BtnStart_Click;



            lstMatchButtons1 = new() {btnMatch1, btnMatch2, btnMatch3, btnMatch4, btnMatch5, btnMatch6, btnMatch7, btnMatch8};
            lstMatchButtons2 = new() {btnMatch9, btnMatch10, btnMatch11, btnMatch12, btnMatch13, btnMatch14, btnMatch15, btnMatch16 };


            lstMatchButtons1.ForEach(b => b.Click += Card1Clicked);
            lstMatchButtons2.ForEach(b => b.Click += Card2Clicked);

            lstMatchStrings = new() { "A", "B", "C", "D", "E", "F", "G", "H"};
            lstMatchButtons1.ForEach(b => b.Enabled = false);
            lstMatchButtons2.ForEach(b => b.Enabled = false);
            lstMatchButtons1.ForEach(b => b.ForeColor = Color.DarkBlue);
            lstMatchButtons2.ForEach(b => b.ForeColor = Color.DarkBlue);


            lblGameStatus.Text = "Click Start to begin game";
        }




        private void AddWordsToButton()
        {
            Random rnd = new();
            lstMatchButtons1 = lstMatchButtons1.OrderBy(x => rnd.Next()).ToList();
            //assign text to lables
            for (int i = 0; i < 8; i++)
            {
                lstMatchButtons1[i].Text = lstMatchStrings[i];
                lstMatchButtons2[i].Text = lstMatchStrings[i];
            }
        }

        private void RevealPictures1(Button btn)
        {
            if (btn.ForeColor == Color.DarkBlue)
            {
                btn.ForeColor = Color.White;
            }
            MatchPart1 = btn;
        }

        private void RevealPictures2(Button btn)
        {
            if (btn.ForeColor == Color.DarkBlue)
            {
                btn.ForeColor = Color.White;
            }
            MatchPart2 = btn;
        }

        private void CheckMatch()
        {
            if (MatchPart1.Text== MatchPart2.Text)
            {
               // addScore();
            }
        }

        private void Card2Clicked(object? sender, EventArgs e)
        {

            if (sender is Button && MatchPart2.ForeColor== Color.White )
            {
                RevealPictures2((Button)sender);
            }

            
        }

        private void Card1Clicked(object? sender, EventArgs e)
        {
            if (sender is Button && MatchPart1.ForeColor == Color.White)
            {
                RevealPictures1((Button)sender);
            }
        }


        private void BtnStart_Click(object? sender, EventArgs e)
        {
            lstMatchButtons1.ForEach(b => b.Enabled = true);
            lstMatchButtons2.ForEach(b => b.Enabled = true);
            lstMatchButtons1.ForEach(b => b.ForeColor = Color.DarkBlue);
            lstMatchButtons2.ForEach(b => b.ForeColor = Color.DarkBlue);
            lblGameStatus.Text = "Current Turn: ";
            AddWordsToButton();

        }
    }
}
