function addToCart(id, bookTitle, price, pictureFile) {
    let products = $.cookie("cart-items");
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }
    const count = $("productsCount").val();
    const currentProduct = products.find(x => x.id === id);
    if (currentProduct != undefined) {

        products.find(x => x.id === id).count = currentProduct.count + parseInt(count);
    } else {
        const product = {
            id, name, price, picture, count
        }
        products.push(product);
    }
    $.cookie("cart-item", JSON.stringify(products), { expires: 2, path: "/" });
}
