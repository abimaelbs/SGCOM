angular.module("app").controller("detalhesContatoCtrl", function ($scope, $routeParams, contato) {        
    $scope.contato = contato.data[0];        
});