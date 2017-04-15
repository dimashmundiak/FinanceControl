﻿using FinanceControlExchangeLib;
using System;
using System.Windows.Forms;

namespace FinanceControlApp.Forms
{
    public partial class ExchangeRateForm : Form
    {
        public ExchangeRateForm()
        {
            InitializeComponent();
        }

        private void ExchangeRateForm_Load(object sender, EventArgs e)
        {
            var firstList = CurrencyRates.GetExchangeRates();
            var secondList = CurrencyRates.GetExchangeRates();
            foreach (var item in firstList)
            {
                textBox1.AppendText(item.GetString() + "\n");
            }
            firstList.Insert(0, new CurrencyRate()
            {
                CurrencyName = "гривня",
                CurrencyStringCode = "UAH",
                ExchangeRate = 100
            });
            secondList.Insert(0, new CurrencyRate()
            {
                CurrencyName = "гривня",
                CurrencyStringCode = "UAH",
                ExchangeRate = 100
            });
            firstCurrencyBox.DataSource = firstList;
            secondCurrencyBox.DataSource = secondList;
        }

        private void PerformButton_Click(object sender, EventArgs e)
        {
            if (ValueBox.Text == "" || firstCurrencyBox.SelectedItem == null || secondCurrencyBox.SelectedItem == null) return;
            var firstValue = double.Parse(ValueBox.Text);
            var firstCurrency = firstCurrencyBox.SelectedItem as CurrencyRate;
            var secondCurrency = secondCurrencyBox.SelectedItem as CurrencyRate;
            var result = (firstValue * (firstCurrency.ExchangeRate / 100)) / (secondCurrency.ExchangeRate / 100);
            resultBox.Text = result.ToString();
        }
    }
}