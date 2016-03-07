angular.module("listaTelefonica").config(function ($routeProvider) {
    $routeProvider.when("/contatos", {
        templateUrl: "views/Contatos/contatos.html",
        controller: "listaTelefonicaCtrl",
        resolve: {
            contatos: function (contatosAPI) {
                return contatosAPI.getContatos();
            }
        }
    });
    $routeProvider.when("/novoContato", {
        templateUrl: "views/Contatos/novoContato.html",
        controller: "novoContratoCtrl"                                          
    });
    $routeProvider.when("/detalhesContato/:id", {
        templateUrl: "views/Contatos/detalhesContato.html",
        controller: "detalhesContatoCtrl",
        resolve: {
            contato: function (contatosAPI,$route) {
                return contatosAPI.getContato($route.current.params.id);
            }
        }
    });

    $routeProvider.otherwise({redirectTo: "/contatos"});
});