﻿using System;

public class PatternPrototype
{
    public interface IPrototype<T> where T : IPrototype<T>
    {
        T Clone();
    }

    public interface IProduct
    {
        void Operation();
    }

    public class Product : IPrototype<Product>, IProduct
    {
        private string _name;

        public Product(string name)
        {
            _name = name;
        }

        public Product Clone()
        {
            return new Product(_name);
        }

        public void Operation()
        {
            Console.WriteLine("Operate " + _name + " (" + GetHashCode() + ")");
        }
    }

    public static void Main(string[] args)
    {
        Product prototype = new Product("ProductA");

        IProduct product = prototype;
        product.Operation();

        product = prototype.Clone();
        product.Operation();
    }
}