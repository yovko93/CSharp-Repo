using System;
using System.Collections;
using System.Collections.Generic;

using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> _transactions;

        public Chainblock()
        {
            this._transactions = new Dictionary<int, ITransaction>();
        }


        public int Count => this._transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this._transactions.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException();
            }

            this._transactions[tx.Id] = tx;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be less or equal to 0.");
            }

            if (!Enum.IsDefined(typeof(TransactionStatus), newStatus))
            {
                throw new InvalidOperationException();
            }

            if (!this._transactions.ContainsKey(id))
            {
                throw new ArgumentException();
            }
           
            var transaction = this._transactions[id];

            if (transaction.Status == newStatus)
            {
                throw new Exception();
            }

            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (!this._transactions.ContainsValue(tx))
            {
                return false;
            }

            return true;
        }

        public bool Contains(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
             
            if (!this._transactions.ContainsKey(id))
            {
                return false;
            }

            return true;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
