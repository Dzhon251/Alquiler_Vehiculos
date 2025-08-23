var unCliente = () => {
    var clienteId = $("#ClienteModelId").val();
    if (!clienteId) return;

    $.get(`/api/ClientesModelApi/${clienteId}`, (uncliente) => {
        document.getElementById("Licencia").value = uncliente.licencia;
        document.getElementById("Telefono").value = uncliente.telefono;
    });
};

var Lista_Vehiculos = () => {
    $.get(`/api/VehiculosModelApi`, (listavehiculos) => {
        let html = "";
        $.each(listavehiculos, (index, vehiculo) => {
            let precioDiario = vehiculo.Precio_Diario ?? 0;

            html += `<tr>
                <td>${vehiculo.marca} ${vehiculo.modelo}</td>
                <td>${vehiculo.anio}</td>
                <td><input type='number' min="1" value="1" id="qty_${vehiculo.id}" class="form-control"/></td>
                <td><input type='number' min="1" value="1" id="dias_${vehiculo.id}" class="form-control"/></td>
                <td>${precioDiario}</td>
                <td>
                    <button type="button"
                        data-id="${vehiculo.id}"
                        data-nombre="${vehiculo.marca} ${vehiculo.modelo}"
                        data-precio="${precioDiario}"
                        onclick="cargarVehiculo(this)"
                        class="btn btn-success">+</button>
                </td>
            </tr>`;
        });
        $("#Lista_prodcutos").html(html);
    });
};

var cargarVehiculo = (btn) => {
    let id = $(btn).data("id");
    let nombre = $(btn).data("nombre");
    let precio = parseFloat($(btn).data("precio"));
    let cantidad = parseInt($(`#qty_${id}`).val());
    let dias = parseInt($(`#dias_${id}`).val());

    if (cantidad <= 0 || dias <= 0) return;

    if ($(`#fila_${id}`).length > 0) {
        let currentQty = parseInt($(`#fila_${id} td:eq(2)`).text());
        let currentDias = parseInt($(`#fila_${id} td:eq(3)`).text());
        let newQty = currentQty + cantidad;
        let newDias = currentDias + dias;
        $(`#fila_${id} td:eq(2)`).text(newQty);
        $(`#fila_${id} td:eq(3)`).text(newDias);
        $(`#fila_${id} td:eq(4)`).text((newQty * newDias * precio).toFixed(2));
    } else {
        let fila = `<tr id="fila_${id}">
            <td>${nombre}</td>
            <td>${precio}</td>
            <td>${cantidad}</td>
            <td>${dias}</td>
            <td>${(precio * cantidad * dias).toFixed(2)}</td>
            <td><button type="button" class="btn btn-danger" onclick="removerVehiculo(${id})">X</button></td>
        </tr>`;
        $("#vehiculosTable tbody").append(fila);
    }

    actualizarTotal();
};

var removerVehiculo = (id) => {
    $(`#fila_${id}`).remove();
    actualizarTotal();
};

var actualizarTotal = () => {
    let total = 0;
    $("#vehiculosTable tbody tr").each(function () {
        total += parseFloat($(this).find("td:eq(4)").text());
    });
    $("#Total_Alquiler").val(total.toFixed(2));
};
