var SaleObject = new Object();

SaleObject.AddProductToCart = function (productId) {
    var name = $("#name_" + productId).val();
    var quantity = $("#qtt_" + productId).val();

    $.ajax({
        type: "POST",
        url: "/api/addProductsToCart",
        dataType: "JSON",
        cache: false,
        async: true,
        data: {
            "productId": productId, "productName": name, "purchaseAmount": quantity
        },
        success: function (data) {
            if(data.success) {
                alert("oK")
            } else {
                alert("Usuário não logado")
            }
        }
    });
}

// Rename function: LoadProduct to ListProductsWithStock
SaleObject.ListProductsWithStock = function () {
    $.ajax({
        type: "GET",
        url: "/api/listProductsWithStock",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {
            var htmlContent = "";

            data.forEach(function (productEntity) {
                htmlContent += "<div class='col-xs-12 col-md-4 col-md-4 col-lg-4'>";
                var nameId = "name_" + productEntity.id;
                var quantityId = "qtt_" + productEntity.id;
                htmlContent += "<label id='" + nameId + "'> Produto: " + productEntity.name + "</label><br/>";
                htmlContent += "<label> Valor: " + productEntity.value + "</label><br/>";
                htmlContent += "Quantidade: <input type='number' id='" + quantityId + "' value='1' />";
                htmlContent += "<input type='button' onclick='SaleObject.AddProductToCart(\""+productEntity.id+"\")' value='Comprar'/><br/>";
                htmlContent += "</div>";
            });
            $("#divForSale").html(htmlContent);
        }
    });
}

$(function () {
    SaleObject.ListProductsWithStock();
});
