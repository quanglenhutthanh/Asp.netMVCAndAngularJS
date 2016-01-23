app.service("angularService", function ($http) {
    this.getProduct = function () {
        return $http.get("/Home/GetAllProducts");
    }
})