using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HesapMakinesi1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double sonuc = 0, sayi = 0;
        bool IslemDevamEdiyor = false;
        bool SonucGosteriliyor = false;

        private void btnSayi_Click(object sender, EventArgs e)
        {
            if (IslemDevamEdiyor || SonucGosteriliyor)
            {
                ISLEM.Text = "0";
                IslemDevamEdiyor = false;
                SonucGosteriliyor = false;
            }

            Button s = (Button)sender;

            if (ISLEM.Text == "0")
                ISLEM.Text = "";

            ISLEM.Text += s.Text;
        }

        private void butonVirgul_Click(object sender, EventArgs e)
        {
            if (IslemDevamEdiyor || SonucGosteriliyor)
            {
                ISLEM.Text = "0";
                IslemDevamEdiyor = false;
                SonucGosteriliyor = false;
            }

            if (ISLEM.Text.IndexOf(",") < 0)
                ISLEM.Text += ",";
        }

        private void butonSpace_Click(object sender, EventArgs e)
        {
            if (IslemDevamEdiyor || SonucGosteriliyor)
            {
                ISLEM.Text = "0";
                IslemDevamEdiyor = false;
                SonucGosteriliyor = false;
            }

            if (ISLEM.Text.Length > 0)
            {
                if (ISLEM.Text != "0")
                {
                    ISLEM.Text = ISLEM.Text.Substring(0, (ISLEM.Text.Length - 1));

                    if (ISLEM.Text == "")
                        ISLEM.Text = "0";
                }
            }
        }

        private void frmHesapMakinesi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Keys k = (Keys)e.KeyChar;

            object sbtn = new object();

            if (k == Keys.D0)
                sbtn = (object)buton0;
            else if (k == Keys.D1)
                sbtn = (object)buton1;
            else if (k == Keys.D2)
                sbtn = (object)buton2;
            else if (k == Keys.D3)
                sbtn = (object)buton3;
            else if (k == Keys.D4)
                sbtn = (object)buton4;
            else if (k == Keys.D5)
                sbtn = (object)buton5;
            else if (k == Keys.D6)
                sbtn = (object)buton6;
            else if (k == Keys.D7)
                sbtn = (object)buton7;
            else if (k == Keys.D8)
                sbtn = (object)buton8;
            else if (k == Keys.D9)
                sbtn = (object)buton9;


            if (k == Keys.D0 ||
                k == Keys.D1 ||
                k == Keys.D2 ||
                k == Keys.D3 ||
                k == Keys.D4 ||
                k == Keys.D5 ||
                k == Keys.D6 ||
                k == Keys.D7 ||
                k == Keys.D8 ||
                k == Keys.D9)
            {
                btnSayi_Click(sbtn, new EventArgs());
            }
            else if (e.KeyChar == 44)
            {
                butonVirgul_Click(butonVirgul, new EventArgs());
            }
            else if (k == Keys.Back)
            {
                butonSpace_Click(butonSpace, new EventArgs());
            }
            else if (e.KeyChar == 43)
            {
                butonArti_Click(butonArti, new EventArgs());
            }
            else if (e.KeyChar == 45)
            {
                butonCikar_Click(butonCikar, new EventArgs());
            }
            else if (e.KeyChar == 42)
            {
                butonCarp_Click(butonCarp, new EventArgs());
            }
            else if (e.KeyChar == 47)
            {
                butonBol_Click(butonBol, new EventArgs());
            }
            else if (e.KeyChar == 13) //eşittir
            {
                butonEsittir_Click(butonEsittir, new EventArgs());
            }
            else if (e.KeyChar == 67 || e.KeyChar == 99) //sıfırla Cc
            {
                butonSifirla_Click(butonSifirla, new EventArgs());
            }
            else if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }

        string Islem = "";

        void IslemiYap(string _Islem)
        {
            sayi = Convert.ToDouble(ISLEM.Text);

            if (ISLEM.Text.Length > 0)
            {
                if (SonucGosteriliyor)
                {
                    Islem = _Islem;
                    DETAY.Text = DETAY.Text.Substring(0, DETAY.Text.Length - 3) + " " + Islem + " ";
                }
                else
                {
                    if (sonuc == 0)
                    {
                        Islem = _Islem;
                        sonuc = sayi;
                        DETAY.Text += sonuc.ToString() + " " + Islem + " ";
                        IslemDevamEdiyor = true;
                    }
                    else
                    {
                        switch (Islem)
                        {
                            case "+":
                                sonuc = sonuc + sayi;
                                break;
                            case "-":
                                sonuc = sonuc - sayi;
                                break;
                            case "*":
                                sonuc = sonuc * sayi;
                                break;
                            case "/":
                                sonuc = sonuc / sayi;
                                break;
                        }

                        string strN = "n" + Num.Value.ToString();

                        ISLEM.Text = sonuc.ToString(strN);

                        Islem = _Islem;

                        if (Islem == "=")
                        {
                            Islem = "";
                            DETAY.Text = "";
                            sonuc = 0;
                            sayi = 0;
                            IslemDevamEdiyor = false;
                            SonucGosteriliyor = false;
                        }
                        else
                        {
                            DETAY.Text += sayi + " " + Islem + " ";
                            IslemDevamEdiyor = false;
                            SonucGosteriliyor = true;
                        }
                    }
                }
            }
        }

        private void butonArti_Click(object sender, EventArgs e)
        {
            IslemiYap("+");
        }

        private void butonCikar_Click(object sender, EventArgs e)
        {
            IslemiYap("-");
        }

        private void butonCarp_Click(object sender, EventArgs e)
        {
            IslemiYap("*");
        }

        private void butonBol_Click(object sender, EventArgs e)
        {
            IslemiYap("/");
        }

        private void butonEsittir_Click(object sender, EventArgs e)
        {
            IslemiYap("=");
        }

        private void butonSifirla_Click(object sender, EventArgs e)
        {
            Islem = "";
            DETAY.Text = "";
            ISLEM.Text = "0";
            sonuc = 0;
            sayi = 0;
            IslemDevamEdiyor = false;
            SonucGosteriliyor = false;
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }       
    }
}
