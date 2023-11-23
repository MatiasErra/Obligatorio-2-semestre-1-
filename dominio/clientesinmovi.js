var clientes = [];


// Click en el botón Alta cliente
function altaCliente()
{
	
	
  if(faltanDatosCli()== false)
	{
		alert("la informacion esta incompleta")
		
	}
	else
	{
		var id = document.getElementById('idCliente').value;
		if (indiceCliente(id) != -1) 
			{
			alert('El cliente ya existe.');
			}
		else 
			{
		clientes.push({
		
            id:       	id,
            nombre:   	document.getElementById('nombreCliente').value,
            apellido: 	document.getElementById('apellidoCliente').value,
			ci:   		document.getElementById('ciCliente').value,
            telefono:   document.getElementById('telefonoCli').value,
			email:     document.getElementById('emailCli').value,
			direccion:  document.getElementById('direccionCli').value
		})
	
        mostrarClientes();
			}	
    }
}

// Click en el botón Baja cliente
function bajaCliente()
 {
	var id = document.getElementById('idCliente').value;
	if(id == " ")
		{
		alert("debe seleccionar un cliente de la lista")
		}
	else
		{
	var i = indiceCliente(id);
			if (i == -1) 
		{	
        alert('El cliente no existe.');
		}
		else
		{
			clientes.splice(i, 1);
			mostrarClientes();
			alert("Cliente eliminado")
			document.getElementById('clientes').reset();
		}
		}
}

// Click en el botón Modificar cliente
function modificarCliente() 
{
    var id = document.getElementById('idCliente').value;
    var i = indiceCliente(id);
    if (i == -1) 
	{
        alert('Debe seleccionar un cliente de la lista.');
    }
    else 
	{
        var cliente = clientes[i];
        cliente.nombre 		= document.getElementById('nombreCliente').value;
        cliente.apellido 	= document.getElementById('apellidoCliente').value;
		cliente.ci 			= document.getElementById('ciCliente').value;
        cliente.telefono 	= document.getElementById('telefonoCli').value;
		cliente.email 		= document.getElementById('emailCli').value;
		cliente.direccion 	= document.getElementById('direccionCli').value;
        mostrarClientes();
		alert("cliente modificado")
    }
}

// Click en la lista de clientes
function seleccionarCliente() 
{

      var lista = document.getElementById("listaClientes")
	var indice = lista.selectedIndex;
        document.getElementById('idCliente').value       = clientes[indice].id;
        document.getElementById('nombreCliente').value   = clientes[indice].nombre;
        document.getElementById('apellidoCliente').value = clientes[indice].apellido;
		document.getElementById('ciCliente').value		 = clientes[indice].ci;
        document.getElementById('telefonoCli').value	 = clientes[indice].telefono;
		document.getElementById('emailCli').value		 = clientes[indice].email;
		document.getElementById('direccionCli').value	 = clientes[indice].direccion;
    
}

function mostrarClientesEnLista(listaClientes) 
{
    var lista = document.getElementById(listaClientes);
    lista.innerHTML = '';
    for(var i = 0; i < clientes.length; i++) 
	{
        var cliente = clientes[i];
        var elemento = document.createElement('option');
       elemento.value = cliente.id
       elemento.text = cliente.id + ' ' + cliente.nombre
		
	
        lista.add(elemento);
    }
}

function mostrarClientes() 
{
    
    mostrarClientesEnLista('listaClientes');
	mostrarClientesEnLista('clientesVenta')
   
}

function indiceCliente(id) 
{
    for (var i = 0; i < clientes.length; i++) 
	{
        if (clientes[i].id == id) 
		{
            return i;
        }
    }
    return -1;
}


function faltanDatosCli()
{
	if(document.getElementById("idCliente").value == "" ||
	   document.getElementById("ciCliente").value == "" ||
	   document.getElementById("nombreCliente").value == "" ||
	   document.getElementById("apellidoCliente").value == "" ||
	   document.getElementById("telefonoCli").value == "" ||
	   document.getElementById("emailCli").value == "" ||
	   document.getElementById("direccionCli").value == "")
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