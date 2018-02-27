var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {

    var appId = "InsuranceUI";
    var appKey = "ThisInsuranceIsPersist";

    $scope.ResetForm = function () {
        $scope.GetAllData();
        $scope.ReqClient = "";
        $scope.ReqInsurance = "";      
    }

    $scope.GetInsurances = function () {
        $http({
            method: "GET",
            headers: {
                'X-InsuranceAppApiKey': appId + ':' + appKey,
                'Content-Type': 'application/json'
            },
            url: "/api/Insurances"
        }).then(function (response) {
            $scope.insurances = response.data;
        }, function () {
            alert("Ocurrió un error en el método GetInsurances()");
        })
    }

    $scope.InsertData = function () {
        $scope.Request = {};
        $scope.Request.ClientId = $scope.ReqClient;
        $scope.Request.InsuranceId = $scope.ReqInsurance;        
        $http({
            method: "POST",
            url: "api/Requests",
            headers: {
                'X-InsuranceAppApiKey': appId + ':' + appKey,
                'Content-Type': 'application/json'
            },
            datatype: "json",
            data: JSON.stringify($scope.Request)
        }).then(function (response) {                
            $scope.ResetForm();
            alert('Registro creado con éxito!');
        }, function (err) {               
            console.log(err);           
            alert("Ocurrió un error en el método Crear");
        })        
    }
    $scope.GetAllData = function () {
        $http({
            method: "GET",
            headers: {
                'X-InsuranceAppApiKey': appId + ':' + appKey,
                'Content-Type': 'application/json'
            },
            url: "/api/Requests"
        }).then(function (response) {
            $scope.requests = response.data;
        }, function () {
            alert("Ocurrió un error en el método GetAllData()");
            })        
    };
    $scope.GetAllData = function () {
        $scope.GetInsurances();
        $http({
            method: "GET",
            headers: {
                'X-InsuranceAppApiKey': appId + ':' + appKey,
                'Content-Type': 'application/json'
            },
            url: "/api/Requests"
        }).then(function (response) {
            $scope.requests = response.data;
        }, function () {
            alert("Ocurrió un error en el método GetAllData()");
        })
    };
    $scope.DeleteRequest = function (Req) {
        $http({
            method: "DELETE",
            headers: {
                'X-InsuranceAppApiKey': appId + ':' + appKey,
                'Content-Type': 'application/json'
            },
            url: "/api/Requests/" + Req.Id,
            datatype: "json",           
        }).then(function (response) {           
            $scope.GetAllData();
            alert('Registro eliminado con éxito!');
        }, function () {
            alert("Ocurrió un error en el método Delete()");
        })
    };
})  