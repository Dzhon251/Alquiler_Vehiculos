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

