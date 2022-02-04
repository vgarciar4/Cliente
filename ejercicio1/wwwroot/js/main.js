
/**
 * ************************************************************
 * ARREGLOS Y OBJETOS
 * ************************************************************
 */

let contactos = [];

/**
 * ************************************************************
 * REFERENCIA A CONTROLES Y COMPONENTES
 * ************************************************************
 */
const bodyTablaContactos = $('#tbodyTablaContactos');


/**
 * ************************************************************
 * FUNCIONES
 * ************************************************************
 */

/**
 * fUNCION ENCARGADA DE REGISTRAR EL CLIENTE
 * @returns VOID
 */
function guardarCliente() {

    //DATOS PERSONALES
    let idCliente = $('#idCliente').val();
    let nit = $('#nit').val();
    let primerNombre = $('#primerNombre').val();
    let segundoNombre = $('#segundoNombre').val();
    let primerApellido = $('#primerApellido').val();
    let segundoApellido = $('#segundoApellido').val();
    let edad = $('#edad').val();
    let sexo = $('#sexo').val();
    let tipoIdentifacion = $('#tipoIdentifacion').val();
    let noIdentificacion = $('#noIdentificacion').val();

    if (!nit || !primerNombre || !primerApellido || !edad
        || !sexo || !tipoIdentifacion || !noIdentificacion) {
        showAlert('error', 'Debe completar todos los campos de datos personales');
        return;
    }


    //PAGO
    let tipoTarjeta = $('#tipoTarjeta').val();
    let noTarjeta = $('#noTarjeta').val();
    let vencimiento = $('#vencimiento').val();
    let ccv = $('#ccv').val();

    if (!tipoTarjeta || !noTarjeta || !vencimiento || !ccv) {
        showAlert('error', 'Debe completar todos los campos de pago');
        return;
    }

    if (ccv.length != 3) {
        showAlert('error', 'El codigo CCV de la tarjeta debe poseer 3 caracteres');
        return;
    }

    //CONTACTO
    if (contactos.length == 0) {
        showAlert('error', 'Debe agregar al menos un contacto');
        return;
    }

    //Negocio
    let nitNegocio = $('#nitNegociPropio').val();
    let nombreNegocio = $('#nombreNegocioPropio').val();
    let direccionNegocio = $('#direccionNegocioPropio').val();
    let telefonoNegocio = $('#telefonoNegocioPropio').val();

    let valorNegocio = $('input:radio[name=rbtnNegocio]:checked').val();

    if (valorNegocio == 'S') {
        if (!nitNegocio || !nombreNegocio || !direccionNegocio || !telefonoNegocio) {
            showAlert('error', 'Debe completar todos los campos de datos de Negocio Propio');
            return;
        } else {

            if (telefonoNegocio.length != 8) {
                showAlert('error', 'El numero de telefono del negocio es incorrecto, debe tener 8 numeros');
                return;
            }
        }
    }


    // vehiculo
    let marcaVehiculo = $('#marcaVehiculo').val();
    let modeloVehiculo = $('#modeloVehiculo').val();
    let lineaVehiculo = $('#lineaVehiculo').val();
    let costoAproVehiculo = $('#costoAproVehiculo').val();

    let valorVehiculo = $('input:radio[name=rbtnvehiculo]:checked').val();

    if (valorVehiculo == 'S') {
        if (!marcaVehiculo || !modeloVehiculo || !lineaVehiculo || !costoAproVehiculo) {
            showAlert('error', 'Debe completar todos los campos de datos del Vehiculo');
            return;

        }

    }

    //Objetos literales
    let cliente = {
        idCliente: idCliente,
        nit: nit,
        primerNombre: primerNombre,
        segundoNombre: segundoNombre,
        primerApellido: primerApellido,
        segundoApellido: segundoApellido,
        edad: edad,
        sexo: sexo,
        idTipoIdentificacion: tipoIdentifacion,
        numeroIdentificacion: noIdentificacion,
    }

    let pago = {
        idTipoTarjeta: tipoTarjeta,
        numeroTarjeta: noTarjeta,
        vencimiento: vencimiento,
        ccv: ccv,
    }
    let negocio = {
        valorNegocio: valorNegocio,
        nitNegocio: nitNegocio,
        nombreNegocio: nombreNegocio,
        direccionNegocio: direccionNegocio,
        telefonoNegocio: telefonoNegocio
    }
    let vehiculo = {
        valorVehiculo: valorVehiculo,
        marcaVehiculo: marcaVehiculo,
        modeloVehiculo: modeloVehiculo,
        lineaVehiculo: lineaVehiculo,
        costoAproVehiculo: costoAproVehiculo
    }

    //Objeto que agrupa toda la informacion para ser enviada
    let dataCliente = {
        cliente: cliente,
        pago: pago,
        contactos: contactos,
        negocio: negocio,
        vehiculo: vehiculo
    }

    console.log(dataCliente);

    let url = (idCliente && idCliente > 0) ? '/Cliente/ActualizarCliente' : '/Cliente/InsertCliente';

    $.ajax({
        url: url,
        type: 'POST',
        data: JSON.stringify(dataCliente),
        contentType: "application/json; charset=utf-8",
        dataType: 'JSON',
        success: function (resp) {
            console.log(resp);
            if (resp.statusCode == 200) {
                showAlertReload('success', 'Proceso completado exitosamente');
            } else {
                showAlert('success', 'Ocurrio un error al completar el proceso');
            }
        }
    });

}


/**
 * Funcion encargada de agregar contactos al listado
 * @returns {void}
 */
function agregarContacto() {

    let tipoContacto = $('#tipoContacto');
    let contacto = $('#contacto');
    let contactoPrincipal = $('#contactoPrincipal');

    if (tipoContacto.val() == '' || contacto.val() == '' || contactoPrincipal.val() == '') {
        showAlert('error', 'Debe completar todos los campos');
        return;
    }

    if (tipoContacto.val() == 'TEL') {
        if (contacto.val().length != 8) {
            showAlert('error', 'El numero de telefono es incorrecto, debe tener 8 numeros');
            return;
        }
    } else {

        //Expresion regular que valida si el correo es valido
        let expEmail = /^([a-zA-Z0-9]+@[a-z0-9]+\.[a-z]{2,3})*$/;

        if (!expEmail.exec(contacto.val())) {
            showAlert('error', 'El correo electronico es invalido');
            return;
        }

    }

    let contactoInfo = {
        tipo: tipoContacto.val(),
        tipoContacto: tipoContacto.find('option:selected').text(),
        contacto: contacto.val(),
        principal: contactoPrincipal.val()
    }

    contactos.push(contactoInfo);
    listarContactos();


    //Limpia los componentes
    tipoContacto.val('TEL').trigger('change');
    contacto.val('');
    contactoPrincipal.val('N').trigger('change');

    $('#mdlNewContacto').modal('hide');


}

/**
 * Muestra la lista de contactos añadidos en la tabla de contactos
 */
function listarContactos() {

    bodyTablaContactos.empty();

    if (contactos.length == 0) return;

    for (let i = 0; i < contactos.length; i++) {

        let tr = `
                <tr>
                    <td class="text-center">${i + 1} </td>
                    <td> ${(contactos[i].tipo == 'TEL') ? 'TELEFONO' : 'CORREO' }</td>
                    <td> ${contactos[i].contacto} </td>
                    <td class="text-center"> ${(contactos[i].principal == 'S') ? 'Si' : 'No'} </td>
                    <td class="text-center">
                        <button class="btn btn-danger btn-sm"
                                title="Eliminar"
                                onclick="eliminarContacto( ${i} )">
                                X
                        </button>
                    </td>
                </tr>
            `;

        bodyTablaContactos.append(tr);

    }

}

/**
 * Permite eliminar un contacto del arreglo y llama a la funcion list6ar, para que muestra
 * los contactos que siguen existiendo
 * @param {number} index Recibe el index de la posicion del contacto en el arreglo
 */
function eliminarContacto(index) {
    contactos.splice(index, 1);
    listarContactos();
}


/**
 * El evento del select tipoContacto llamara a esta funcion que segun el tipo de contacto
 * seleccionado, cambiara el tipo de input, si es email o number, asi como el texto
 */
function tipoContacto() {

    let tipoContacto = $('#tipoContacto');
    let contacto = $('#contacto');

    contacto.val('');

    if (tipoContacto.val() == 'TEL') {
        contacto.attr('type', 'number')
        contacto.attr('placeholder', 'Ingresar telefono')
    } else {
        contacto.attr('type', 'email')
        contacto.attr('placeholder', 'Ingresar correo')
    }

}

/**
 * Funcion que muestra una alerta del plugin SweetAlert
 * @param {string} tipo Tipo de alerta a mostrar (success, error)
 * @param {string} mensaje Mensaje que desea mostrar en la alerta
 */
function showAlert(tipo, mensaje) {

    let title = (tipo == 'success') ? 'Completado' :
        (tipo == 'error') ? 'Error' : 'Atencion';

    Swal.fire({
        icon: tipo,
        title: title,
        text: mensaje,
    })

}


//evento para mostrar negocio propio 


$(document).ready(function () {
    $("input[name=rbtnNegocio]").click(function (evento) {

        let valor = $('input:radio[name=rbtnNegocio]:checked').val();

        if (valor == 'S') {
            $("#divNegocioPropio").show(600);

        } else {
            $("#divNegocioPropio").hide(600);

        }
    });
});



//evento para mostrar vehiculo propio

$(document).ready(function () {
    $("input[name=rbtnvehiculo]").click(function (evento) {

        let valor = $('input:radio[name=rbtnvehiculo]:checked').val();

        if (valor == 'S') {
            $("#divVehiculo").show(600);

        } else {
            $("#divVehiculo").hide(600);

            //Limpiar formulario de negocio
            $("#marcaVehiculo").val('');
            $("#modeloVehiculo").val('');
            $("#lineaVehiculo").val('');
            $("#costoAproVehiculo").val('');
        }
    });
});
