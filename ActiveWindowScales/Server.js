
var http = require('http'),
    url = require('url'),
    exec = require('child_process').exec,
    fs = require('fs');


var host = "172.16.28.145",
    port = "8989",
    thisServerUrl = "http://" + host + ":" + port;


var scales_local_path = "C:\\Talma\\Scales.Windows\\";
var command_path = scales_local_path + "Scales.Windows.exe";
var command_path_clear = "C:\\Talma\\AgenteScalesHermes\\script\\ClearProcess.bat";


http.createServer(function (req, res) {
    req.addListener('end', function () { });

    var query = require('url').parse(req.url, true).query;
    var cmd = query.cmd;
    var prm1 = query.prm1;
    var prm2 = query.prm2;
    var prm3 = query.prm3;
    var prm4 = query.prm4;
    var prm5 = query.prm5;
    var prm6 = query.prm6;
    var prm7 = query.prm7;
    var prm8 = query.prm8;
    var prm9 = query.prm9;
    var prm10 = query.prm10;

    res.writeHead(200, { 'Content-Type': 'text/plain' });

    if (cmd) {
        if (cmd == "scl") {

            exec(command_path_clear, (err, stdout, stderr) => {
                if (err) {
                    console.error(err);
                }
                //console.log(stdout);	
                setTimeout(() => {
                    console.log('esperando cierre scales...');
                }, 2000);

                exec(command_path + " " + prm1 + "@" + prm2 + "@" + prm3 + "@" + prm4 + "@" + prm5 + "@" + prm6 + "@" + prm7 + "@" + prm8 + "@" + prm9 + "@" + prm10, function (error, stdout, stderr) {
                    if (error != null) {
                        res.end('ERR|' + error + '\n');
                    }
                    else {
                        res.end("OK");

                        //let utils = new Utileria(fs);
                        //let archivo = "./scl/" + prm6 
                        //let mensaje = prm1 + "|" + prm2 + "|" + prm3 + "|" + prm4 + "|" + prm5 + "|" + prm6 + "|" + prm7 + "|" + prm8 + "|" + prm9 //+ "|" + prm10

                        //utils.escibir(archivo, mensaje, function (err) {
                        //	if (err) {
                        //return console.log(err);
                        //		res.end('ERR|' +  error + '\n');
                        //	}
                        //console.log("Archivo escrito correctamente!")
                        //});


                    }
                });

            });

        }
    }
    else {
        var result = ('ERR| CMD is mandatory, use the right format:' + '\n' + 'http://[IP ADDRESS]:[PORT]/?cmd=scl&prm1=<Group ISN>&prm2=<AWB number>&prm3=<House>&prm4=<Destination>&prm5=<Return file - Path>' + '\n' + '&prm6=<Return file - Filename>&prm7=<Pieces>&prm8=<Consignee>&prm9=<Manifest number>&prm10=<COM Port number>' + '\n');
        res.end(result + '\n');
    }

}).listen(port, host);
console.log('Server running at ' + thisServerUrl);



class Utileria {

    constructor(fs) {
        this.fs = fs;
    }

    /**
     * @param {string} archivo ruta relativa o absoluta del archivo a escribir
     * @param {string} contenido Contenido del archivo a escribir.
     * @param {function} funcion que maneja el evento al termino del mismo
     */
    escibir(archivo, contenido, handler) {
        this.fs.writeFile(archivo, contenido, handler);
    }

    /**
     * @param {string} archivo ruta relativa o absoluta del archivo a escribir
     * @param {function} funcion que maneja el evento al termino del mismo
     */
    leer(archivo, handler) {
        this.fs.readFile(archivo, 'utf8', handler);
    }
}

