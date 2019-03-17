namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Abstractions;

    public class Product : Entity
    {
        private readonly List<CartProduct> _cartProducts;

        private readonly List<OrderProduct> _orderProducts;

        private readonly List<ProductCategory> _productCategories;

        private readonly List<ProductFile> _productFiles;

        public Guid Id { get; private set; }

        public bool Active { get; set; } = true;

        public string Description { get; set; }

        public bool IsDownload { get; set; }

        public string Name { get; set; }

        public string QuantityPerUnit { get; set; }

        public int? ReorderLevel { get; set; }

        public string Sku { get; set; }

        public int? UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public int? UnitsOnOrder { get; set; }

        public virtual IReadOnlyCollection<CartProduct> CartProducts => _cartProducts;

        public virtual IReadOnlyCollection<OrderProduct> OrderProducts => _orderProducts;

        public virtual IReadOnlyCollection<ProductCategory> ProductCategories => _productCategories;

        public virtual IReadOnlyCollection<ProductFile> ProductFiles => _productFiles;

        public Product()
        {
            _cartProducts = new List<CartProduct>();
            _productCategories = new List<ProductCategory>();
            _productFiles = new List<ProductFile>();
            _orderProducts = new List<OrderProduct>();
        }

        public Product(Guid id) : this()
        {
            Id = id;
        }

        public void AddCartProduct(CartProduct cartProduct)
        {
            _cartProducts.Add(cartProduct);
        }

        public bool RemoveCartProduct(CartProduct cartProduct)
        {
            return _cartProducts.Remove(cartProduct);
        }

        public void AddOrderProduct(OrderProduct orderProduct)
        {
            _orderProducts.Add(orderProduct);
        }

        public bool RemoveOrderProduct(OrderProduct orderProduct)
        {
            return _orderProducts.Remove(orderProduct);
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            _productCategories.Add(productCategory);
        }

        public bool RemoveProductCategory(ProductCategory productCategory)
        {
            return _productCategories.Remove(productCategory);
        }

        public void AddProductFile(ProductFile productFile)
        {
            _productFiles.Add(productFile);
        }

        public bool RemoveProductFile(ProductFile productFile)
        {
            return _productFiles.Remove(productFile);
        }
    }
}
