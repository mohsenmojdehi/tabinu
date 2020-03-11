var Cart = {

    AddToCart: function (id, typeOfService) {
        var TypeOfService = 1; //advertisement
        //graphicdesign
        if (typeOfService === 0) {
            var TypeOfService = 0;
        }
        $.post("/Order/AddToCart",
            {
                TypeOfService: TypeOfService,
                Id:id
            }, function(data) {
                Cart.UpdateCartView();
            });
    },

    UpdateCartView: function() {
        $.get("/Order/Cart", {}, function(data) {
            $("#CartHolder").html(data);
        });
    }
}