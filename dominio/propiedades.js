 var propiedades = [];


// Click en el botón Alta cliente
function altaPropiedad()
{
	
	if(faltanDatosProp()== false)
	{
		alert("la informacion esta incompleta")
		
	}
	else
	{	
		var id = document.getElementById('idPropiedad').value;
		if (indiceProp(id) != -1) 
			{
			alert('La propiedad ya existe.');
			}
		else 
			{
        
			propiedades.push({
		
				Id:       	id,
				M2:   	document.getElementById('mts2').value,
				Dormitorios: 	document.getElementById('dormitorios').value,
				Tipo:		document.getElementById('tipoProp').value,
				Banos:   		document.getElementById('banos').value,
				Garaje:   document.getElementById('garaje').value,
				Parrillero:   document.getElementById('parrillero').value,
				Barrio:     document.getElementById('barrio').value,
				Ciudad:     document.getElementById('ciudad').value,
				Direccion:  document.getElementById('direccionProp').value,
				Precio:     	document.getElementById('precio').value
				})
	
			mostrarProp();
			}		
	}
}

// Click en el botón Baja cliente
function bajaPropiedad()
 {
	 
    var id = document.getElementById('idPropiedad').value;
	if(id == " ")
		{
		alert("debe seleccionar una propiedad de la lista")
		}
		else
		{
	var i = indiceProp(id);
		if (i == -1) 
		{	
        alert('El propiedad no existe.');
		}
    else
	{
        propiedades.splice(i, 1);
        mostrarProp();
        document.getElementById('propiedades').reset();
		alert("propiedad eliminada")
    }
	}	
}

// Click en el botón Modificar cliente
function modificarProp() 
{
    var id = document.getElementById('idPropiedad').value;
	if(id == " ")
	{
		alert("debe seleccionar una propiedad de la lista")
	}
    else 
	{
        var i = indiceProp(id);
		if(i != -1)
		{	
			propiedades[i].M2 		= document.getElementById('mts2').value;
			propiedades[i].Dormitorios 	= document.getElementById('dormitorios').value;
			propiedades[i].Banos 		= document.getElementById('banos').value;
			propiedades[i].Tipo 		= document.getElementById('tipoProp').value;
			propiedades[i].Garaje 			= document.getElementById('garaje').value;
			propiedades[i].Parrillero 	= document.getElementById('parrillero').value;
			propiedades[i].Ciudad 		= document.getElementById('ciudad').value;
			propiedades[i].Direccion 	= document.getElementById('direccionProp').value;
			propiedades[i].Barrio 	= document.getElementById('barrio').value;
			propiedades[i].Precio 	= document.getElementById('precio').value;
			mostrarProp();
			alert("Propiedad modificada con exito")
		}	
		else
		{
			alert("Propiedad no existe en la lista")	
		}	
    }
}

// Click en la lista de clientes
function seleccionarPropiedades() 
{
    
	var lista = document.getElementById("listaProp")
	var indice = lista.selectedIndex;
       
        document.getElementById('idPropiedad').value       = propiedades[indice].Id;
		document.getElementById('mts2').value       = propiedades[indice].M2;
        document.getElementById('dormitorios').value   	= propiedades[indice].Dormitorios;
		document.getElementById('tipoProp').value   	= propiedades[indice].Tipo;
        document.getElementById('banos').value 			= propiedades[indice].Banos;
        document.getElementById('garaje').value     	= propiedades[indice].Garaje;
		document.getElementById('parrillero').value		 = propiedades[indice].Parrillero;
        document.getElementById('ciudad').value	 		= propiedades[indice].Ciudad;
		document.getElementById('direccionProp').value		 = propiedades[indice].Direccion;
		document.getElementById('barrio').value			 = propiedades[indice].Barrio;
		document.getElementById('precio').value			 = propiedades[indice].Precio;
    
}

function mostrarPropiedadesEnLista(listaProp) 
{
    var lista = document.getElementById(listaProp);
    lista.innerHTML = ' ';
    for(var i = 0; i < propiedades.length; i++) 
	{
        var cliente = propiedades[i];
        var elemento = document.createElement('option');
        elemento.value = cliente.Id
       elemento.text = cliente.Id + ' ' 
		+ cliente.Barrio + ' ' 
		+ cliente.Ciudad + ' '
		+ cliente.Direccion + ' $'
		+ cliente.Precio
		
		
        lista.add(elemento);
    }
}

function mostrarProp() 
{
    
    mostrarPropiedadesEnLista('listaProp');
   mostrarPropiedadesEnLista('cantidadVenta')
}

function indiceProp(id) 
{
    for (var i = 0; i < propiedades.length; i++) 
	{
        if (propiedades[i].Id == id) 
		{
            return i;
        }
    }
    return -1;
}

function faltanDatosProp()
{
	if(document.getElementById("idPropiedad").value == "" ||
	   document.getElementById("mts2").value == "" ||
	   document.getElementById("tipoProp").value == "" ||
	   document.getElementById("dormitorios").value == "" ||
	   document.getElementById("banos").value == "" ||
	   document.getElementById("garaje").value == "" ||
	   document.getElementById("parrillero").value == "" ||
	   document.getElementById("barrio").value == "" ||
	   document.getElementById("ciudad").value == "" ||
	   document.getElementById("direccionProp").value == "" ||
	   
	   document.getElementById("precio").value == "")	
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