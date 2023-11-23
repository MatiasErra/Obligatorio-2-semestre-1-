
	 
	function mostrarCartera()
	{
	
	var contador = 0
	var ven = prompt("Ingrese el id de un  vendedor")
	
	for(var i =0; i<vendedores.length; i++)
	{	
		if(vendedores[i].id == ven)
		{
			var can= vendedores[i].nombre	
			for(var i=0; i<ventas.length; i++)
			{
				if(ventas[i].Vendedor == ven)
				{
					
				contador++
				}
			
			}
		}
	}
			
	reportar("las ventas que realizo " + can + " fueron "+ contador) 
	}
	
	
	
	
	
	
	
		function clienteCompras()
	{
		var texto = " "
	
	var comp = prompt("Ingrese el id de un comprador")
	
	for(var i =0; i<clientes.length; i++)
	{	
		if(clientes[i].id == comp)
		{
			var can = clientes[i].nombre	
			for(var i=0; i<ventas.length; i++)
			{
				if(ventas[i].Cliente == comp)
				{
					var venta=ventas[i]
					texto += '<br>' + venta.Id + ' ' 
					+ venta.Fecha + ' '
					+ venta.Monto + ' '
					+ venta.Propiedad + ' '
					+ venta.Vendedor + ' ' 
					+ can + ' '
				
				}
			
			}
		}
	}
			
	reportar("las compras de " + comp + " fueron " + texto)
	}
	
	
	function propCara()
	{
		var mayor=0
		for (var i=0; i<ventas.length; i++)
		{
		for(var i=0; i<vendedores.length; i++)
		{
			if(ventas[i].Vendedor == vendedores[i].id)
			{
				var ven = vendedores[i].nombre
				for(var i=0; i<ventas.length; i++)
				{
					if(ventas[i].Monto > mayor)
					{
					mayor = ventas[i].Monto
					}
				}
			}
		}
		}
		reportar("la venta mas grande fue de " + mayor + " realizada por " + ven)
		
	}
	
	
	function precioCiudad()
	{
		var pol=[]
		var texto= " " 
		var barrio = prompt("ingrese una barrio")
		var monto  = prompt("ingrese un monto de dinero")
		for(var i = 0; i<propiedades.length; i++)
		{
			if(barrio == propiedades[i].Barrio && propiedades[i].Precio<monto )
			{
						pol.push('<br>' + propiedades[i].Id + 
						' ' + propiedades[i].Barrio +
						' ' + propiedades[i].Ciudad  + 
						' $' + propiedades[i].Precio)	
			}				
		}
		return pol
	}
	
	function Consulta5()
	{
		var resultado=precioCiudad()
		reportar("Las propiedades con esos datos son: " + resultado)
	}
	
	
	
	

	
	function reportar(texto) 
	{
    document.getElementById('resultadoConsulta').innerHTML = texto;
	}

	function CopiarVendedores() {
   
    for (var i = 0; i < vendedores.length; i++) {
        copiaVend.push(vendedores[i]);
	}
    }
	
