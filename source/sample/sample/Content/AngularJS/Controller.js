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

    $scope.add = function () {
        $scope.ID = "";
        $scope.Name = "";
        $scope.IsModification = true;
        $scope.operation = "Add"
    }
    $scope.update = function (product) {
        $scope.ID = product.ID;
        $scope.Name = product.Name;
        $scope.IsModification = true;
        $scope.operation = "Update"
    }
    $scope.close = function () {
        $scope.IsModification = false;
    }
    $scope.save = function () {
        var product = {
            ID: $scope.ID,
            Name: $scope.Name,
            CategoryID: 1
        };
        var Operation = $scope.operation;
        if (Operation == "Add") {
            var getMSG = angularService.Add(product);
            getMSG.then(function (messagefromController) {
                getAll();
                alert(messagefromController.data);
                $scope.IsModification = false;
            }, function () {
                alert('Insert Error');
            });
        } else {
            var getMSG = angularService.Update(product);
            getMSG.then(function (messagefromController) {
                getAll();
                alert(messagefromController.data);
                $scope.IsModification = false;
            }, function () {
                alert('Insert Error');
            });
        }
    }

    $scope.delete = function (product) {
        var productID = product.ID;
        alert(productID);
        var getMSG = angularService.Delete(productID);
        getMSG.then(function (messagefromController) {
            getAll();
            alert(messagefromController.data);
        }, function () {
            alert('Insert Error');
        });
    }
})