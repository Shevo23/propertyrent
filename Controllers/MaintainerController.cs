using Microsoft.AspNetCore.Mvc;
using InmueblesWeb.Data;
using InmueblesWeb.Models;

namespace InmueblesWeb.Controllers
{
    public class MaintainerController : Controller
    {
        UsuarioData usuarioData = new UsuarioData();
        RolesData rolesData = new RolesData();
        TipoIdentificacionData identificacionData = new TipoIdentificacionData();
        TipoPropiedadData propiedadData = new TipoPropiedadData();

        #region Usuarios

        public IActionResult GetList()
        {
            var oList = usuarioData.GetUsuarios();

            return View(oList);
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = usuarioData.SaveUsuario(usuarioModel);

            if (response)
            {
                return RedirectToAction("GetList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int idUsuario)
        {
            var oUsuario = usuarioData.GetUsuario(idUsuario);

            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Edit(UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = usuarioData.EditUsuario(usuarioModel);

            if (response)
            {
                return RedirectToAction("GetList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int idUsuario)
        {
            var oUsuario = usuarioData.GetUsuario(idUsuario);

            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Delete(UsuarioModel usuarioModel)
        {
            var response = usuarioData.DeleteUsuario(usuarioModel.IdUsuario, 0);

            if (response)
            {
                return RedirectToAction("GetList");
            }
            else
            {
                return View();
            }
        }

        #endregion

        #region Roles

        public IActionResult EditRoles(int idRol)
        {
            var oUsuario = rolesData.GetRol(idRol);

            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult EditRoles(RolesModel rolesModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = rolesData.EditRol(rolesModel);

            if (response)
            {
                return RedirectToAction("GetListRoles");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult SaveRoles(RolesModel rolesModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = rolesData.SaveRol(rolesModel);

            if (response)
            {
                return RedirectToAction("GetListRoles");
            }
            else
            {
                return View();
            }
        }

        public IActionResult SaveRoles()
        {
            return View();
        }

        public IActionResult GetListRoles()
        {
            var oListaRoles = rolesData.GetRoles();
            return View(oListaRoles);
        }

        #endregion

        #region TipoIdentificacion

        public IActionResult EditTipoIdentificacion(int idTipoIdentificacion)
        {
            var oUsuario = identificacionData.GetTipoIdentificacion(idTipoIdentificacion);

            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult EditTipoIdentificacion(TipoIdentificacionModel  tipoIdentificacionModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = identificacionData.EditTipoIdentificacion(tipoIdentificacionModel);

            if (response)
            {
                return RedirectToAction("GetListTiposIdentificacion");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult SaveTipoIdentificacion(TipoIdentificacionModel tipoIdentificacionModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = identificacionData.SaveTipoIdentificacion(tipoIdentificacionModel);

            if (response)
            {
                return RedirectToAction("GetListTiposIdentificacion");
            }
            else
            {
                return View();
            }
        }

        public IActionResult SaveTipoIdentificacion()
        {
            return View();
        }

        public IActionResult GetListTiposIdentificacion()
        {
            var oListaRoles = identificacionData.GetTipoIdentificacion();
            return View(oListaRoles);
        }

        #endregion

        #region TipoPropiedad

        public IActionResult EditTipoPropiedad(int idTipoPropiedad)
        {
            var oPropiedad = propiedadData.GetTipoPropiedad(idTipoPropiedad);

            return View(oPropiedad);
        }

        [HttpPost]
        public IActionResult EditTipoPropiedad(TipoPropiedadModel tipoPropiedadModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = propiedadData.EditTipoPropiedad(tipoPropiedadModel);

            if (response)
            {
                return RedirectToAction("GetListTipoPropiedad");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult SaveTipoPropiedad(TipoPropiedadModel tipoPropiedadModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = propiedadData.SaveTipoPropiedad(tipoPropiedadModel);

            if (response)
            {
                return RedirectToAction("GetListTipoPropiedad");
            }
            else
            {
                return View();
            }
        }

        public IActionResult SaveTipoPropiedad()
        {
            return View();
        }

        public IActionResult GetListTipoPropiedad()
        {
            var oListaRoles = propiedadData.GetTipoPropiedad();
            return View(oListaRoles);
        }

        #endregion
    }
}
