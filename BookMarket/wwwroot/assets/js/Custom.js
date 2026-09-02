const cookieName = "cart-items";
function addToCart(id, bookTitle, price, pictureFile)
{
    let products = $.cookie(cookieName);
    debugger;
    if (products === undefined)
    {
        products = [];
    } else
    {
        products = JSON.parse(products);
    }

    const count = $("#prudoctCount").val();

    const currentProduct = products.find(x => x.id == id);

    if (currentProduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentProduct.count)+ parseInt(count);
    } else {
        const product = {
            id,
            bookTitle,
            price,
            pictureFile,
            count
        };

        products.push(product);
    }

    $.cookie(cookieName, JSON.stringify(products), {
        expires: 2,
        path: "/"
    });
    console.log("Cart:", products);
});
