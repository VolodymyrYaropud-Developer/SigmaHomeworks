
using Homework8.Task3;

Product p1 = new Product("boo", 1, 0.1);
Product p2 = new Product("bob", 2, 0.1);
Product p3 = new Product("boo", 3, 0.1);
Product p4 = new Product("bob", 4 , 0.1);
Product p5 = new Product("boo", 5, 0.1);

Product p6 = new Product("bob", 5, 0.1);


Composition c1 = new Composition(new List<Product>() { p1, p3, p5 });
Composition c2 = new Composition(new List<Product>() { p2, p4, p6, p4, p5 });
c1.UnionElements(c2);
