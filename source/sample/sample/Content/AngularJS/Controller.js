app.controller("AngularCtrl", function ($scope, angularService) {
    $scope.name = "quanglnt";
    getAll();
    function getAll() {
        //alert('get all');
        var data = angularService.getProduct();
        data.then(function (product) {
            $scope.products = product.data;
           
        }, function () {
            alert('error');
        })
    }
})