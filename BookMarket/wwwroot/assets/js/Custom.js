const cookieName = "cart-items";

function addToCart(id, bookTitle, price, pictureFile) {

    let products = $.cookie(cookieName);

    if (products === undefined) {
        products = [];
    }
    else {
        products = JSON.parse(products);
    }

    const count = $("#productCount").val();

    const currentProduct = products.find(x => x.id == id);

    if (currentProduct !== undefined) {
        products.find(x => x.id == id).count =
            parseInt(currentProduct.count) + parseInt(count);
    }
    else {
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
    updateCart();
}

function updateCart() {

    let products = $.cookie(cookieName); 

    if (products === undefined) {
        products = [];
    }
    else {
        products = JSON.parse(products);
    }

    $("#cart_items_count").text(products.length);

    let cartItemsWrapper = $("#cart_items_wrapper");

    cartItemsWrapper.html("");

    products.forEach(x => {

        const product = `<div class="product">
            <div class="product-cart-details">
                <h4 class="product-title">
                    <a href="product.html">${x.bookTitle}</a>
                </h4>

                <span class="cart-product-info">
                    <span class="cart-product-qty">${x.count} x </span>
                    ${x.price}
                </span>
            </div>

            <figure class="product-image-container">
                <a href="product.html" class="product-image">
                    <img src="/Pictures/${x.pictureFile}" alt="محصول">
                </a>
            </figure>

            <a href="#" class="btn-remove" title="حذف محصول">
                <i class="icon-close"onclick="removeFromCart('${x.id}')" ></i>
            </a>
        </div>`;

        cartItemsWrapper.append(product);
    });
}
function removeFromCart(id) {
    let products = $.cookie(cookieName);

    if (products === undefined) {
        products = [];
    }
    else {
        products = JSON.parse(products);
    }
    let itemToRemove = products.findIndex(x => x.id === id);
    products.splice(itemToRemove, 1);

    $.cookie(cookieName, JSON.stringify(products), {
        expires: 2,
        path: "/"
    });
    updateCart();
}
