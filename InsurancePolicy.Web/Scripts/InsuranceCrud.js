var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {

    var appId = "InsuranceUI";
    var appKey = "ThisInsuranceIsPersist";

    $scope.ResetForm = function () {
        $scope.GetAllData();
        $scope.InsName = "";
        $scope.InsDescription = "";
        $scope.InsType = "";
        $scope.InsCoverage = "";
        $scope.InsValidity = "";
        $scope.InsPeriod = "";
        $scope.InsPrice = "";
        $scope.InsRisk = "";
        document.getElementById("btnSave").innerHTML = "Guardar";
        document.getElementById("spn").innerHTML = "Adicionar Póliza de Seguro";
    }

    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").innerHTML;
        if (Action == "Guardar") {
            $scope.Insurance = {};
            $scope.Insurance.Name = $scope.InsName;
            $scope.Insurance.Description = $scope.InsDescription;
            $scope.Insurance.Type = $scope.InsType;
            $scope.Insurance.Coverage = $scope.InsCoverage;
            $scope.Insurance.Validity = $scope.InsValidity;
            $scope.Insurance.Period = $scope.InsPeriod;
            $scope.Insurance.Price = $scope.InsPrice;
            $scope.Insurance.Risk = $scope.InsRisk;
            $http({
                method: "POST",
                url: "api/Insurances",
                headers: {
                    'X-InsuranceAppApiKey': appId + ':' + appKey,
                    'Content-Type': 'application/json'
                },
                datatype: "json",
                data: JSON.stringify($scope.Insurance)
            }).then(function (response) {                
                $scope.ResetForm();
                alert('Registro creado con éxito!');
            }, function (err) {               
                console.log(err)
                if (err.data.ModelState.insurance != null && err.data.ModelState.insurance.length > 0)
                    alert(err.data.ModelState.insurance[0]);
                else
                    alert("Ocurrió un error en el método Crear");
            })
        } else {
            $scope.Insurance = {};
            $scope.Insurance.Name = $scope.InsName;
            $scope.Insurance.Description = $scope.InsDescription;
            $scope.Insurance.Type = $scope.InsType;
            $scope.Insurance.Coverage = $scope.InsCoverage;
            $scope.Insurance.Validity = $scope.InsValidity;
            $scope.Insurance.Period = $scope.InsPeriod;
            $scope.Insurance.Price = $scope.InsPrice;
            $scope.Insurance.Risk = $scope.InsRisk;
            $scope.Insurance.Id = document.getElementById("InsID_").value;
            $http({
                method: "PUT",
                url: "api/Insurances/" + document.getElementById("InsID_").value,
                headers: {
                    'X-InsuranceAppApiKey': appId + ':' + appKey,
                    'Content-Type': 'application/json'
                },
                datatype: "json",
                data: JSON.stringify($scope.Insurance)
            }).then(function (response) {                
                $scope.ResetForm();  
                alert('Registro actualizado con éxito!');
            }, function (err) {                
                console.log(err);
                if (err.data.ModelState.insurance != null && err.data.ModelState.insurance.length > 0)
                    alert(err.data.ModelState.insurance[0]);    
                else 
                    alert("Ocurrió un error en el método Actualizar");
            })
        }
    }
    $scope.GetAllData = function () {
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
            alert("Ocurrió un error en el método GetAllData()");
        })
    };
    $scope.DeleteInsurance = function (Ins) {
        $http({
            method: "DELETE",
            headers: {
                'X-InsuranceAppApiKey': appId + ':' + appKey,
                'Content-Type': 'application/json'
            },
            url: "/api/Insurances/" + Ins.Id,
            datatype: "json",           
        }).then(function (response) {           
            $scope.GetAllData();
            alert('Registro eliminado con éxito!');
        }, function () {
            alert("Ocurrió un error en el método Delete()");
        })
    };
    $scope.UpdateInsurance = function (Ins) {
        document.getElementById("InsID_").value = Ins.Id;

        $scope.InsName = Ins.Name;
        $scope.InsDescription = Ins.Description;
        $scope.InsType = Ins.Type;
        $scope.InsCoverage = Ins.Coverage;
        $scope.InsValidity = new Date(Ins.Validity);
        $scope.InsPeriod = Ins.Period;
        $scope.InsPrice = Ins.Price;
        $scope.InsRisk = Ins.Risk;

        document.getElementById("btnSave").innerHTML = "Actualizar";
        document.getElementById("spn").innerHTML = "Actualizar Póliza de Seguro";
    }
})  