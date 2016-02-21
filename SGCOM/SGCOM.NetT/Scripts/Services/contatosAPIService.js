/* factory
angular.module("listaTelefonica").factory("contatosAPI", function ($http, config) {
    var _getContatos = function () {
        return $http.get(config.baseUrl + "/contatos");
    };

    var _saveContato = function (contato) {
        return $http.post(config.baseUrl + "/contatos", contato);
    };

    return {
        getContatos: _getContatos,
        saveContato: _saveContato
    };
}); */

angular.module("listaTelefonica").service("contatosAPI", function ($http, config) {
    this.getContatos = function () {
        return $http.get(config.baseUrl + "/contatos");
    };

    this.saveContato = function (contato) {
        return $http.post(config.baseUrl + "/contatos", contato);
    };

    this.removeContato = function (contato) {
        return $http.post(config.baseUrl + "/contatos", contato);
    };
})