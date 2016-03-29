angular.module("app").controller("listaTelefonicaCtrl", function ($scope, contatos, contatosAPI) {
    $scope.app = "Lista Telefonica";
    $scope.contatos = contatos.data;
    $scope.operadoras = [
        { nome: "OI", codigo: 14, categoria: "Celular", preco: 2 },
        { nome: "Vivo", codigo: 15, categoria: "Celular", preco: 1 },
        { nome: "Tim", codigo: 41, categoria: "Celula", preco: 3 },
        { nome: "GVT", codigo: 25, categoria: "Fixo", preco: 1 },
        { nome: "Embratel", codigo: 21, categoria: "Fixo", preco: 2 }
    ];
   /*
    $scope.adicionarContato = function (contato) {
        contatosAPI.saveContato(contato).success(function (data) {
            delete $scope.contato;
            $scope.contatoForm.$setPristine();
            carregarContatos();
        });
    };
    */
    $scope.apagarContatos = function (contatos) {
        $scope.contatos = this.contatos.filter(function (contato) {
            if (!contato.selecionado) return contato;
            if (contato.selecionado) {                
                contatosAPI.removeContato(contato).success(function (data) {
                    carregarContatos();
                });              
            }
        });
    };
    $scope.isContatoSelecionado = function (contatos) {
        return this.contatos.some(function (contato) {
            return contato.selecionado;
        });
    };
    $scope.ordenarPor = function (campo) {
        $scope.criterioOrdenacao = campo;
        $scope.direcaoOrdenacao = !$scope.direcaoOrdenacao;
    }    
});