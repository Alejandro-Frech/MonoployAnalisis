﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoployAnalisis
{
    public class Player
    {
        public enum PlayerPiece
        {
            Car,
            Dedal,
            Dog,
            Hat,
            Iron,
            Oldboot,
            Ship,
            WheelCart
        };

        private PlayerPiece _piece;
        private int _funds;
        private int _currentPosition;
        private string _name;
        private IList<Property> _ownedProperties;
        public PlayerPiece Piece
        {
            get { return this._piece; }
        }

        public void SetPiece(PlayerPiece piece)
        {
            this._piece = piece;
        }

        public void SetName(string name)
        {
            this._name = name;
        }
        public int Funds
        {
            get { return _funds;  }
        }
        public int CurrentPosition
        {
            get { return _currentPosition; }
        }

        public void SetCurrentPosition(int pos)
        {
            _currentPosition = pos;
        }
        public string Name
        {
            get { return _name; }
        }
        public IList<Property> GetOwnedProperties
        {
            get { return _ownedProperties; }
        }
        public Player()

        {
            _funds = 0;
            _currentPosition = 0;
            _ownedProperties = new List<Property>();

        }

        public int AddFunds(int fundsToAdd)
        {
            _funds += fundsToAdd;
            return Funds;
        }

        public bool ReduceFunds(int fundsToReduce)
        {
            if(Funds < fundsToReduce)
            {
                throw new InsufficientFundsException();
            }
            _funds -= fundsToReduce;
            return true;
        }

        public void TransferFunds(Player receivingPlayer, int amountToTransfer)
        {
            if(Funds < amountToTransfer)
            {
                throw new InsufficientFundsException("Not Enough funds to transfer to other player");
            }

            _funds -= amountToTransfer;
            receivingPlayer.AddFunds(amountToTransfer);
        }

        public void PurchaseProperty(Property property)
        {
            if (Funds < property._cost)
            {
                throw new InsufficientFundsException("Not enough Funds to purchase the property");
            }

            _funds -= property._cost;
            _ownedProperties.Add(property);
            property.Owner = this;
        }
    }
}
