using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        //private readonly Dictionary<string, Item> vaultCells;
        private Item item;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("owner", "id");
        }

        [Test]
        public void PuttingItemOnInvalidCellShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            bankVault.AddItem("G4", item));
        }

        [Test]
        public void PuttinhItemOnTakenCellShouldThrowException()
        {
            bankVault.AddItem("A1", new Item("dsf", "sdf"));

            Assert.Throws<ArgumentException>(() =>
            bankVault.AddItem("A1", item));
        }

        [Test]
        public void TrySavingSameItemOnAnotherCellShouldThrowException()
        {
            bankVault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() =>
            bankVault.AddItem("A1", item));
        }

        [Test]
        public void SuccessfullySavedItemShouldReturnMessage()
        {
            var actualResult = bankVault.AddItem("A1", item);

            var expectedResult = "Item:id saved successfully!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SuccessfullyRemovedItemShouldReturnExpectedMessage()
        {
            bankVault.AddItem("A1", item);

            var actualResult = bankVault.RemoveItem("A1", item);

            var expectedResult = "Remove item:id successfully!";

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void TryRemoveItemFromNonExistingCellShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            bankVault.RemoveItem("B89", item));
        }

        [Test]
        public void TryRemoveItemFromWrongExistingCellShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            bankVault.RemoveItem("A1", item));
        }
    }
}