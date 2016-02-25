angular.module("listaTelefonica").config(function ($routeProvider) {
    $routeProvider.when("/contatos", {
        templateUrl: "views/contatos.html",
        controller: "listaTelefonicaCtrl"
    });
    $routeProvider.when("/novoContato", {
        templateUrl: "views/novoContato.html",
        controller: "novoContratoCtrl"
    });
    $routeProvider.otherwise({redirectTo: "/contatos"});
});