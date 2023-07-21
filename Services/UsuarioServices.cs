using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23AM.Context;
using ProyectoFinal_23AM.Entities;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//#FF296EB7

namespace ProyectoFinal_23AM.Services
{
    public class UsuarioServices
    {
        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Usuario res = new Usuario()
                        {
                            Nombre = request.Nombre,
                            UserName = request.UserName,
                            Password = request.Password,
                            FkRol = request.FkRol,
                        };
                        _context.Usuarios.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error "+ ex.Message);
            }
        }
        public void UpdateUser(Usuario request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuario update = _context.Usuarios.Find(request.PkUsuario);

                    update.Nombre = request.Nombre;
                    update.UserName = request.UserName;
                    update.Password = request.Password;
                    update.FkRol = request.FkRol;

                    _context.Usuarios.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public void DeleteUser(int UserId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuario usuario = _context.Usuarios.Find(UserId);

                    if(usuario != null)
                    {
                        _context.Usuarios.Remove(usuario);
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("No existe el registro");
                    }

                }
            }

            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Usuario> GetUsuarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Usuario> usuarios = new List<Usuario>();

                    usuarios = _context.Usuarios.Include(x => x.Roles).ToList();

                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = new List<Rol>();

                    roles = _context.Roles.ToList();
                    roles.RemoveAt(1);
                    roles.RemoveAt(0);
                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
        public Usuario Login(string UserName, string Password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var usuario = _context.Usuarios.Include(y => y.Roles).FirstOrDefault(x=> x.UserName==UserName && x.Password==Password);
                    return usuario;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
    }
}
