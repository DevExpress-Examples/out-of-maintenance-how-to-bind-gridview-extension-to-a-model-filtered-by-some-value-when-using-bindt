using System.Collections.Generic;
using CS.Models;
using System.Linq;
using System.Collections;
using System;
using System.Data.Linq;


public static class LargeDatabaseDataProvider {
    static LargeDatabaseDataContextDataContext db;
    public static LargeDatabaseDataContextDataContext DB {
        get {
            if (db == null)
                db = new LargeDatabaseDataContextDataContext();
            return db;
        }
    }
    public static IEnumerable GetProducts() {
        return from product in DB.Products select product;
    }

    public static IList<Product> GetColors() {
        IQueryable<Product> source = (from product in DB.Products
                                      group product by product.Color into products
                                      select products.FirstOrDefault());
        return source.ToList<Product>();
    }

    public static IQueryable<Product> GetProductsByFilter(object colorName) {

        IQueryable<Product> source = from product in DB.Products
                                     where product.Color.Equals(colorName)
                                     select product;
        return source;
    }
}
