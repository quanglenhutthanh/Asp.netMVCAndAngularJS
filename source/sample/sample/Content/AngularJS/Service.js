app.service("angularService", function ($http) {
    this.getProduct = function () {
        return $http.get("/Home/GetAllProducts");
    }

    this.Add = function (product) {
        var response = $http({
            method: "post",
            url: "/Home/AddProduct",
            data: JSON.stringify(product),
            dataType: "json"
        });
        return response;
    }

    this.Update = function (product) {
        var response = $http({
            method: "post",
            url: "/Home/UpdateProduct",
            data: JSON.stringify(product),
            dataType: "json"
        });
        return response;
    }

    this.Delete = function (id) {
        var respone = $http({
            method: "post",
            url: "/Home/DeleteProduct",
            params: {
                id : id
            }
        });
        return respone;
    }
})