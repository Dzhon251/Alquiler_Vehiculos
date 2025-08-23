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
            html += `<tr >
                <td> ${vehiculo.marca} </td>
                <td> ${vehiculo.modelo} </td>
                <td> <input type='number' min="1" value="0" id="qty_${vehiculo.id}"/> </td>
                <td> <button type="button"
                data-id="${vehiculo.id}"
                data-nombre="${vehiculo.marca}"
                data-precio="${vehiculo.modelo}"
                onclick="cargarvehiculos(this)"
                class="btn-success">+</button> </td>
            `;
        })  
        await $("#Lista_prodcutos").html(html)
    })
}
