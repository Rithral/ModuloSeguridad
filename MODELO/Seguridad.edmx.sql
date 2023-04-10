
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/12/2014 20:41:57
-- Generated from EDMX file: c:\users\rithral\documents\visual studio 2013\Projects\FinalModulo\MODELO\Seguridad.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
DROP DATABASE FinalSeguridad
GO
CREATE DATABASE FinalSeguridad
GO
USE [FinalSeguridad];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'perfiles'
CREATE TABLE [dbo].[perfiles] (
    [per_codigo] int IDENTITY(1,1) NOT NULL,
    [formulario_frm_codigo] int  NOT NULL,
    [grupo_gru_codigo] nvarchar(4)  NOT NULL
);
GO

-- Creating table 'grupos'
CREATE TABLE [dbo].[grupos] (
    [gru_codigo] nvarchar(4)  NOT NULL,
    [gru_descripcion] nvarchar(50)  NOT NULL,
    [gru_estado] bit  NOT NULL
);
GO

-- Creating table 'modulos'
CREATE TABLE [dbo].[modulos] (
    [mod_codigo] varchar(5)  NOT NULL,
    [mod_descripcion] varchar(50)  NULL
);
GO

-- Creating table 'usuarios'
CREATE TABLE [dbo].[usuarios] (
    [usu_codigo] nvarchar(100)  NOT NULL,
    [usu_nombre] nvarchar(50)  NOT NULL,
    [usu_clave] nvarchar(100)  NOT NULL,
    [usu_estado] bit  NOT NULL,
    [usu_email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'formularios'
CREATE TABLE [dbo].[formularios] (
    [frm_codigo] int IDENTITY(1,1) NOT NULL,
    [frm_descripcion] nvarchar(50)  NOT NULL,
    [frm_formulario] nvarchar(50)  NOT NULL,
    [frm_estado] bit  NOT NULL,
    [modulo_mod_codigo] varchar(5)  NOT NULL
);
GO

-- Creating table 'permisos'
CREATE TABLE [dbo].[permisos] (
    [per_codigo] nvarchar(1)  NOT NULL,
    [per_descripcion] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'permisoperfil'
CREATE TABLE [dbo].[permisoperfil] (
    [permiso_per_codigo] nvarchar(1)  NOT NULL,
    [perfil_per_codigo] int  NOT NULL
);
GO

-- Creating table 'usuariogrupo'
CREATE TABLE [dbo].[usuariogrupo] (
    [grupos_gru_codigo] nvarchar(4)  NOT NULL,
    [usuario_usu_codigo] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'formulariopermiso'
CREATE TABLE [dbo].[formulariopermiso] (
    [formulario_frm_codigo] int  NOT NULL,
    [permiso_per_codigo] nvarchar(1)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [per_codigo] in table 'perfiles'
ALTER TABLE [dbo].[perfiles]
ADD CONSTRAINT [PK_perfiles]
    PRIMARY KEY CLUSTERED ([per_codigo] ASC);
GO

-- Creating primary key on [gru_codigo] in table 'grupos'
ALTER TABLE [dbo].[grupos]
ADD CONSTRAINT [PK_grupos]
    PRIMARY KEY CLUSTERED ([gru_codigo] ASC);
GO

-- Creating primary key on [mod_codigo] in table 'modulos'
ALTER TABLE [dbo].[modulos]
ADD CONSTRAINT [PK_modulos]
    PRIMARY KEY CLUSTERED ([mod_codigo] ASC);
GO

-- Creating primary key on [usu_codigo] in table 'usuarios'
ALTER TABLE [dbo].[usuarios]
ADD CONSTRAINT [PK_usuarios]
    PRIMARY KEY CLUSTERED ([usu_codigo] ASC);
GO

-- Creating primary key on [frm_codigo] in table 'formularios'
ALTER TABLE [dbo].[formularios]
ADD CONSTRAINT [PK_formularios]
    PRIMARY KEY CLUSTERED ([frm_codigo] ASC);
GO

-- Creating primary key on [per_codigo] in table 'permisos'
ALTER TABLE [dbo].[permisos]
ADD CONSTRAINT [PK_permisos]
    PRIMARY KEY CLUSTERED ([per_codigo] ASC);
GO

-- Creating primary key on [permiso_per_codigo], [perfil_per_codigo] in table 'permisoperfil'
ALTER TABLE [dbo].[permisoperfil]
ADD CONSTRAINT [PK_permisoperfil]
    PRIMARY KEY CLUSTERED ([permiso_per_codigo], [perfil_per_codigo] ASC);
GO

-- Creating primary key on [grupos_gru_codigo], [usuario_usu_codigo] in table 'usuariogrupo'
ALTER TABLE [dbo].[usuariogrupo]
ADD CONSTRAINT [PK_usuariogrupo]
    PRIMARY KEY CLUSTERED ([grupos_gru_codigo], [usuario_usu_codigo] ASC);
GO

-- Creating primary key on [formulario_frm_codigo], [permiso_per_codigo] in table 'formulariopermiso'
ALTER TABLE [dbo].[formulariopermiso]
ADD CONSTRAINT [PK_formulariopermiso]
    PRIMARY KEY CLUSTERED ([formulario_frm_codigo], [permiso_per_codigo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [formulario_frm_codigo] in table 'perfiles'
ALTER TABLE [dbo].[perfiles]
ADD CONSTRAINT [FK_formularioperfil]
    FOREIGN KEY ([formulario_frm_codigo])
    REFERENCES [dbo].[formularios]
        ([frm_codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_formularioperfil'
CREATE INDEX [IX_FK_formularioperfil]
ON [dbo].[perfiles]
    ([formulario_frm_codigo]);
GO

-- Creating foreign key on [grupo_gru_codigo] in table 'perfiles'
ALTER TABLE [dbo].[perfiles]
ADD CONSTRAINT [FK_grupoperfil]
    FOREIGN KEY ([grupo_gru_codigo])
    REFERENCES [dbo].[grupos]
        ([gru_codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_grupoperfil'
CREATE INDEX [IX_FK_grupoperfil]
ON [dbo].[perfiles]
    ([grupo_gru_codigo]);
GO

-- Creating foreign key on [permiso_per_codigo] in table 'permisoperfil'
ALTER TABLE [dbo].[permisoperfil]
ADD CONSTRAINT [FK_permisoperfil_permiso]
    FOREIGN KEY ([permiso_per_codigo])
    REFERENCES [dbo].[permisos]
        ([per_codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [perfil_per_codigo] in table 'permisoperfil'
ALTER TABLE [dbo].[permisoperfil]
ADD CONSTRAINT [FK_permisoperfil_perfil]
    FOREIGN KEY ([perfil_per_codigo])
    REFERENCES [dbo].[perfiles]
        ([per_codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_permisoperfil_perfil'
CREATE INDEX [IX_FK_permisoperfil_perfil]
ON [dbo].[permisoperfil]
    ([perfil_per_codigo]);
GO

-- Creating foreign key on [grupos_gru_codigo] in table 'usuariogrupo'
ALTER TABLE [dbo].[usuariogrupo]
ADD CONSTRAINT [FK_usuariogrupo_grupo]
    FOREIGN KEY ([grupos_gru_codigo])
    REFERENCES [dbo].[grupos]
        ([gru_codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [usuario_usu_codigo] in table 'usuariogrupo'
ALTER TABLE [dbo].[usuariogrupo]
ADD CONSTRAINT [FK_usuariogrupo_usuario]
    FOREIGN KEY ([usuario_usu_codigo])
    REFERENCES [dbo].[usuarios]
        ([usu_codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_usuariogrupo_usuario'
CREATE INDEX [IX_FK_usuariogrupo_usuario]
ON [dbo].[usuariogrupo]
    ([usuario_usu_codigo]);
GO

-- Creating foreign key on [modulo_mod_codigo] in table 'formularios'
ALTER TABLE [dbo].[formularios]
ADD CONSTRAINT [FK_moduloformulario]
    FOREIGN KEY ([modulo_mod_codigo])
    REFERENCES [dbo].[modulos]
        ([mod_codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_moduloformulario'
CREATE INDEX [IX_FK_moduloformulario]
ON [dbo].[formularios]
    ([modulo_mod_codigo]);
GO

-- Creating foreign key on [formulario_frm_codigo] in table 'formulariopermiso'
ALTER TABLE [dbo].[formulariopermiso]
ADD CONSTRAINT [FK_formulariopermiso_formulario]
    FOREIGN KEY ([formulario_frm_codigo])
    REFERENCES [dbo].[formularios]
        ([frm_codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [permiso_per_codigo] in table 'formulariopermiso'
ALTER TABLE [dbo].[formulariopermiso]
ADD CONSTRAINT [FK_formulariopermiso_permiso]
    FOREIGN KEY ([permiso_per_codigo])
    REFERENCES [dbo].[permisos]
        ([per_codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_formulariopermiso_permiso'
CREATE INDEX [IX_FK_formulariopermiso_permiso]
ON [dbo].[formulariopermiso]
    ([permiso_per_codigo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------