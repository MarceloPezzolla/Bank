using Bank.Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Test.Entities
{
    [TestClass]
    public class BankAccountTest
    {
        private Mock<IBankAccount> _mock;

        [TestMethod]
        public void BankAccount_AddInterest_BalancePlusInterest_Test_Success()
        {
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;

            _mock.Setup(x => x.AddInterest(It.IsAny<double>()));
            double balanceRes = 16900;
            double balanceUpdated = accountMock.AddInterest(130.00);
            Assert.AreEqual(balanceRes, balanceUpdated);
        }
        [TestMethod]
        public void BankAccount_AddInterest_BalancePlusInterest_Test_Fail()
        {
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;

            _mock.Setup(x => x.AddInterest(It.IsAny<double>()));
            double balanceRes = 18000;
            double balanceUpdated = accountMock.AddInterest(130.00);
            Assert.AreNotEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_AddCredit_BalancePlusCredit_Test_Success()
        {
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;
            double amount = 10;

            _mock.Setup(x => x.Credit(It.IsAny<double>()));
            double balanceRes = 140;
            double balanceUpdated = accountMock.Credit(amount);
            Assert.AreEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_AddCredit_BalancePlusCredit_Test_Fail()
        {
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;
            double amount = 10;

            _mock.Setup(x => x.Credit(It.IsAny<double>()));
            double balanceRes = 175;
            double balanceUpdated = accountMock.Credit(amount);
            Assert.AreNotEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_AddCreditExcepetion_Test()
        {
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;
            double amount = -10.0;

            _mock.Setup(x => x.Credit(It.IsAny<double>()));

            Assert.ThrowsException<Exception> (() => accountMock.Credit(amount));
        }

        [TestMethod]
        public void BankAccount_Debit_BalanceMinusDebit_Test_Success()
        {
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;
            double amount = 10;

            _mock.Setup(x => x.Debit(It.IsAny<double>()));
            double balanceRes = 119.75;
            double balanceUpdated = accountMock.Debit(amount);
            Assert.AreEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_Debit_BalanceMinusDebit_Test_Fail()
        {
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;
            double amount = 10;

            _mock.Setup(x => x.Debit(It.IsAny<double>()));
            double balanceRes = 110;
            double balanceUpdated = accountMock.Debit(amount);
            Assert.AreNotEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_DebitExcepetion_AmountAndZero_Test()
        {
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;
            double amount = -10.0;

            _mock.Setup(x => x.Debit(It.IsAny<double>()));

            Assert.ThrowsException<Exception>(() => accountMock.Debit(amount));
        }

        [TestMethod]
        public void BankAccount_DebitExcepetion_AmountAndBalance_Test()
        {
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;
            double amount = 140.00;

            _mock.Setup(x => x.Debit(It.IsAny<double>()));

            Assert.ThrowsException<Exception>(() => accountMock.Debit(amount));
        }
    }
}
