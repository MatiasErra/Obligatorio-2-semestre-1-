 var ventas = [];

var vendedorVenta =[]

// Click en el botón Alta cliente
function altaVenta()
{
	
	if(faltanDatosVenta()== false)
	{
		alert("la informacion esta incompleta")
		
	}
	else
	{	
		var prop = document.getElementById('idPropiedad').value
		var id = document.getElementById('idVenta').value;
		if (indiceVenta(id) != -1 || indiceVenta(prop) != -1) 
			{
			alert('La venta ya existe.');
			}
		else 
			{
        
			ventas.push({
		
				Id:       	id,
				Fecha:   	document.getElementById('fecha').value,
				Monto: 	document.getElementById('monto').value,
				Propiedad:   		document.getElementById('cantidadVenta').value,
				Vendedor:   document.getElementById('vendedorVenta').value,
				Propietario:  document.getElementById('propietarioVenta').value,
				Cliente:     document.getElementById('clientesVenta').value
				})
	
			mostrarVentas();
			
			}		
	}
}

// Click en el botón Baja cliente
function bajaVenta()
 {
	 
    var id = document.getElementById('idVenta').value;
	if(id == " ")
		{
		alert("debe seleccionar una venta de la lista")
		}
		else
		{
	var i = indiceVenta(id);
		if (i == -1) 
		{	
        alert('La venta no existe.');
		}
    else
	{
        ventas.splice(i, 1);
        mostrarVentas();
        document.getElementById('ventas').reset();
		alert("venta eliminada")
    }
	}	
}

// Click en el botón Modificar cliente
function modificarVenta() 
{
    var id = document.getElementById('idVenta').value;
	if(id == " ")
	{
		alert("debe seleccionar una venta de la lista")
	}
    else 
	{
        var i = indiceVenta(id);
		if(i != -1)
		{	
			ventas[i].Id 		= document.getElementById('idVenta').value;
			ventas[i].Fecha 	= document.getElementById('fecha').value;
			ventas[i].Monto 		= document.getElementById('monto').value;
			ventas[i].Propiedad			= document.getElementById('cantidadVenta').value;
			ventas[i].Vendedor 	= document.getElementById('vendedorVenta').value;
			ventas[i].Propietario 		= document.getElementById('propietarioVenta').value;
			ventas[i].Cliente 	= document.getElementById('clientesVenta').value;
			
			mostrarVentas();
			alert("Venta modificada con exito")
		}	
		else
		{
			alert("Venta no existe en la lista")	
		}	
    }
}

// Click en la lista de clientes
function seleccionarVenta() 
{
    
	var lista = document.getElementById("listaVenta")
	var indice = lista.selectedIndex;
       
        document.getElementById('idVenta').value       = ventas[indice].Id;
		document.getElementById('fecha').value       = ventas[indice].Fecha;
        document.getElementById('monto').value   	= ventas[indice].Monto;
        document.getElementById('cantidadVenta').value 			= ventas[indice].Propiedad;
        document.getElementById('vendedorVenta').value     	= ventas[indice].Vendedor;
		document.getElementById('propietarioVenta').value		 = ventas[indice].Propietario;
        document.getElementById('clientesVenta').value	 		= ventas[indice].Cliente; 
		
}

function mostrarVentasEnLista(listaVenta) 
{
    var lista = document.getElementById(listaVenta);
    lista.innerHTML = ' ';
    for(var i = 0; i < ventas.length; i++) 
	{
        var venta = ventas[i];
        var elemento = document.createElement('option');
        elemento.value = venta.Id;
       elemento.text = venta.Id + ' ' 
	    + venta.Fecha + ' $'
	   + venta.Monto + ' '
		+ venta.Propiedad + ' '
		+ venta.Cliente
		
        lista.add(elemento);
    }
}

function mostrarVentas() 
{
    
    mostrarVentasEnLista('listaVenta');
   
}

function indiceVenta(id) 
{
	var prop = document.getElementById('idPropiedad').value
    for (var i = 0; i < ventas.length; i++) 
	{
		{
        if (ventas[i].Id == id || ventas[i].Vendedor == prop) 
			{
            return i;
			}
		}
    }
    return -1;
}

function faltanDatosVenta()
{
	if(document.getElementById("idVenta").value == "" ||
	   document.getElementById("fecha").value == "" ||
	   document.getElementById("monto").value == "" ||
	   document.getElementById("cantidadVenta").value == "" ||
	   document.getElementById("vendedorVenta").value == "" ||
	   document.getElementById("clientesVenta").value == "" ||
	   document.getElementById("propietarioVenta").value == "")	
	{
		return false;
	}
	else
	{
		return true;
	}	
}
function isNumberKey(evt)
 {
	 var charCode = (evt.which) ? evt.which : event.keyCode;
	 return !(charCode >31 && (charCode<48 || charCode >57))
	 
 }

function buscarVendedor(id) 
{
    for (var i = 0; i < vendedores.length; i++) 
    {
        if (vendedores[i].id == id) {
            return vendedores[i];
        }
    }
}

