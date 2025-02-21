function addToCart(productId) {
    fetch(`/Cart/Add`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ productId: productId })
    })
        .then(response => {
            if (response.ok) {
                // Optionally, update the cart UI here
                alert('Product added to cart');
            } else {
                alert('Failed to add product to cart');
            }
        });
}