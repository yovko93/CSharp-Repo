namespace Chainblock.Tests
{
    using System;

    using Chainblock.Contracts;
    using Chainblock.Models;
    using NUnit.Framework;
    using System.Diagnostics;
    using Moq;

    [TestFixture]
    public class ChainblockTests
    {
        public ITransaction Transaction { get; set; }

        public IChainblock Chainblock { get; set; }

        [SetUp]
        public void SetUp()
        {
            //Arrange
            this.Transaction = new Transaction()
            {
                Id = 1,
                From = "Filip",
                To = "Victor",
                Status = TransactionStatus.Successfull,
                Amount = 1
            };

            this.Chainblock = new Chainblock();
        }

        //Given_UserIsAuthenticated_When_InvalidAccountNumberIsUsedToWithdrawMoney_Then_TransactionsWillFail
        //GIVEN_WHEN_THEN

        [Test]
        [Category("Add method")]
        public void Given_Transaction_When_AddTransactionIsCalled_Then_TransactionsCountIncrease()
        {
            //Arrange
            int expectedChainblockCount = 1;

            //Act
            this.Chainblock.Add(this.Transaction);

            //Assert
            Assert.AreEqual(expectedChainblockCount, this.Chainblock.Count);
        }


        [Test]
        [Category("Add method")]
        public void Given_DuplicateTransaction_When_AddTransactionIsCalled_Then_ThrowInvalidOperationException()
        {
            //Act
            this.Chainblock.Add(this.Transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
                this.Chainblock.Add(this.Transaction));
        }

        [Test]
        [Category("Count property")]
        public void Given_PropertyCountValue_WhenCountGetterIsCalled_Then_ProperNumberIsReturn()
        {
            var expectedChainblockCount = 0;

            Assert.AreEqual(expectedChainblockCount, this.Chainblock.Count);
        }

        [Test]
        [Category("[Contains] --> id method")]
        public void Given_ExistingId_When_ContainsByIdIsCalled_Then_ReturnTrue()
        {
            this.Chainblock.Add(this.Transaction);
            bool result = this.Chainblock.Contains(this.Transaction.Id);

            Assert.IsTrue(result);
        }

        [Test]
        [Category("[Contains] --> id method")]
        public void Given_NonExistingId_When_ContainsByIdIsCalled_Then_ReturnFalse()
        {
            Assert.That(this.Chainblock.Contains(this.Transaction.Id), Is.False);

        }

        [Test]
        [Category("[Contains] --> id method")]
        public void Given_NegativeId_When_ContainsByIdIsCalled_Then_ThrowException()
        {
            int invalidId = -1;

            Assert.Throws<ArgumentException>(() =>
                this.Chainblock.Contains(invalidId));
        }

        [Test]
        [Category("[Contains] --> Transaction method")]
        public void Given_ExistingTransaction_When_ContainsByTransactionIsCalled_Then_ReturnTrue()
        {
            this.Chainblock.Add(this.Transaction);

            Assert.That(this.Chainblock.Contains(Transaction), Is.True);
        }

        [Test]
        [Category("[Contains] --> Transaction method")]
        public void Given_NonExistingTransaction_When_ContainsByTransactionIsCalled_Then_ReturnFalse()
        {
            Assert.IsFalse(this.Chainblock.Contains(this.Transaction));
        }


        [Test]
        [Category("[ChangeTransactionStatus] method")]
        public void Given_ValidIdAndStatus_When_ChangeTransactionStatusIsCalled_Then_StatusIsChanged()
        {
            this.Transaction.Status = TransactionStatus.Successfull;

            this.Chainblock.Add(this.Transaction);
            TransactionStatus newStatus = TransactionStatus.Aborted;

            this.Chainblock.ChangeTransactionStatus(this.Transaction.Id, newStatus);

            Assert.AreEqual(newStatus, this.Transaction.Status);
        }

        [Test]
        [Category("[ChangeTransactionStatus] method")]
        public void Given_ValidIdAndSameStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowInvalidOperationException()
        {
            this.Transaction.Status = TransactionStatus.Successfull;

            this.Chainblock.Add(this.Transaction);
            TransactionStatus newStatus = TransactionStatus.Successfull;

            Assert.Throws<Exception>(() =>
             this.Chainblock.ChangeTransactionStatus(this.Transaction.Id, newStatus));
        }

        [Test]
        [Category("[ChangeTransactionStatus] method")]
        public void Given_InvalidIdAndStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowArgumentException()
        {
            this.Chainblock.Add(this.Transaction);
            int notExistingId = 2;

            Assert.Throws<ArgumentException>(() =>
            this.Chainblock.ChangeTransactionStatus(notExistingId, TransactionStatus.Aborted));
        }

        [Test]
        [Category("[ChangeTransactionStatus] method")]
        public void Given_ValidIdAndNonExistingStatusCode_When_ChangeTransactionStatusIsCalled_Then_ThrowInvalidOperationException()
        {
            int invalidTransactionStatusValue = 15;

            Assert.Throws<InvalidOperationException>(() =>
            this.Chainblock.ChangeTransactionStatus(this.Transaction.Id, (TransactionStatus)invalidTransactionStatusValue));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [Category("[ChangeTransactionStatus] method")]
        public void Given_InvalidIdAndStatusCode_When_ChangeTransactionStatusIsCalled_Then_ThrowArgumentException(int invalidId)
        {
            string expectedErrorMessage = "Id cannot be less or equal to 0.";

            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate
                {
                    this.Chainblock.ChangeTransactionStatus(invalidId, TransactionStatus.Successfull);
                });

            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
        }
    }
}
