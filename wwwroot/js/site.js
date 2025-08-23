var unCliente = () => {
    var clienteId = $("#ClienteModelId").val();
    $.get(`/api/ClientesModelApi/${clienteId}`, (uncliente) => {
        document.getElementById("Licencia").value = uncliente.licencia;
        document.getElementById("Telefono").value = uncliente.telefono;
    })
}

var Lista_Vehiculos = () => {
    $.get(`/api/VehiculosModelApi`, async (listavehiculos) => {
        let html = "";
        $.each(listavehiculos, (index, vehiculo) => {
            html += `<tr>
                <td>${vehiculo.marca} ${vehiculo.modelo}</td>
                <td>${vehiculo.anio}</td>
                <td><input type='number' min="1" value="1" id="qty_${vehiculo.id}" class="form-control"/></td>
                <td>${vehiculo.Precio_Diario}</td>
                <td>
                    <button type="button"
                        data-id="${vehiculo.id}"
                        data-nombre="${vehiculo.marca} ${vehiculo.modelo}"
                        data-precio="${vehiculo.Precio_Diario}"
                        onclick="cargarvehiculos(this)"
                        class="btn btn-success">+</button>
                </td>
            </tr>`;
        });
        await $("#Lista_prodcutos").html(html);
    });
}
