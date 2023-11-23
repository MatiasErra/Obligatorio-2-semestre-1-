var vendedores = [];


// Click en el botón Alta cliente
function altaVendedor()
{
	
	
  if(faltanDatosVen()== false)
	{
		alert("la informacion esta incompleta")
		
	}
	else
	{
		var id = document.getElementById('idVendedor').value;
		if (indiceVendedor(id) != -1) 
			{
			alert('El vendedor ya existe.');
			}
		else 
			{
		vendedores.push({
		
            id:       	id,
            nombre:   	document.getElementById('nombreVendedor').value,
            apellido: 	document.getElementById('apellidoVendedor').value,
			ci:   		document.getElementById('ciVendedor').value,
            telefono:   document.getElementById('telefonoVen').value,
			email:     document.getElementById('emailVen').value,
			direccion:  document.getElementById('direccionVen').value,
			cartera:    document.getElementById('carteraVendedor').value
		})
		
				
		
        mostrarVendedores();
			}	
    }
}

// Click en el botón Baja cliente
function bajaVendedor()
 {
	var id = document.getElementById('idVendedor').value;
	if(id == " ")
		{
		alert("debe seleccionar un vendedor de la lista")
		}
	else
		{
	var i = indiceVendedor(id);
			if (i == -1) 
		{	
        alert('El Vendedor no existe.');
		}
		else
		{
			vendedores.splice(i, 1);
			mostrarVendedores();
			alert("Vendedor eliminado")
			document.getElementById('vendedores').reset();
		}
		}
}

// Click en el botón Modificar cliente
function modificarVendedor() 
{
    var id = document.getElementById('idVendedor').value;
    var i = indiceVendedor(id);
    if (i == -1) 
	{
        alert('Debe seleccionar un vendedor de la lista.');
    }
    else 
	{
        var vendedor = vendedores[i];
        vendedor.nombre 		= document.getElementById('nombreVendedor').value;
        vendedor.apellido 	= document.getElementById('apellidoVendedor').value;
        vendedor.cartera 		= document.getElementById('carteraVendedor').value;
		vendedor.ci 			= document.getElementById('ciVendedor').value;
        vendedor.telefono 	= document.getElementById('telefonoVen').value;
		vendedor.email 		= document.getElementById('emailVen').value;
		vendedor.direccion 	= document.getElementById('direccionVen').value;
        mostrarVendedores();
		alert("Vendedor modificado")
    }
}

// Click en la lista de clientes
function seleccionarVendedor() 
{

      var lista = document.getElementById("listaVendedores")
	var indice = lista.selectedIndex;
        document.getElementById('idVendedor').value       = vendedores[indice].id;
        document.getElementById('nombreVendedor').value   = vendedores[indice].nombre;
        document.getElementById('apellidoVendedor').value = vendedores[indice].apellido;
        document.getElementById('carteraVendedor').value     = vendedores[indice].cartera;
		document.getElementById('ciVendedor').value		 = vendedores[indice].ci;
        document.getElementById('telefonoVen').value	 = vendedores[indice].telefono;
		document.getElementById('emailVen').value		 = vendedores[indice].email;
		document.getElementById('direccionVen').value	 = vendedores[indice].direccion;
    
}

function mostrarVendedoresEnLista(listaVendedores) 
{
    var lista = document.getElementById(listaVendedores);
    lista.innerHTML = '';
    for(var i = 0; i < vendedores.length; i++) 
	{
        var vendedor = vendedores[i];
        var elemento = document.createElement('option');
       elemento.value= vendedor.id
       elemento.text = vendedor.id +' ' + vendedor.nombre 
		
		
        lista.add(elemento);
    }
}

function mostrarVendedores() 
{
    
    mostrarVendedoresEnLista('listaVendedores');
   mostrarVendedoresEnLista('vendedorVenta')
}

function indiceVendedor(id) 
{
    for (var i = 0; i < vendedores.length; i++) 
	{
        if (vendedores[i].id == id) 
		{
            return i;
        }
    }
    return -1;
}


function faltanDatosVen()
{
	if(document.getElementById("idVendedor").value == "" ||
	   document.getElementById("ciVendedor").value == "" ||
	   document.getElementById("nombreVendedor").value == "" ||
	   document.getElementById("apellidoVendedor").value == "" ||
	   document.getElementById("telefonoVen").value == "" ||
	   document.getElementById("emailVen").value == "" ||
	   document.getElementById("direccionVen").value == "" ||
	   document.getElementById("carteraVendedor").value == "")
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
 
 