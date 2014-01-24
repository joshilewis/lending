﻿using System;

namespace Core.Model
{
    public abstract class Ownership
    {
        public virtual Guid Id { get; protected set; }
        public virtual Item Item { get; protected set; }

        protected Ownership() { }

        public Ownership(Item item)
        {
            Item = item;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Id.Equals(((Ownership) obj).Id);

        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }

    public class Ownership<T> : Ownership where T : IOwner
    {
        public virtual T Owner { get; protected set; }

        protected Ownership() { }

        public Ownership(Item item, T owner)
            : base(item)
        {
            Owner = owner;
        }
        
    }

}
