export enum RouterAppEnum {
  Base = '/',
  Home = '',
}

export enum LocalStorageKeyEnum {
  SystemParameter = 'SYS_SETTING',
  SessionToken = 'SESSION_TOKEN',
}

export enum ThemeEnum {
  Light = 'Light',
  Dark = 'Dark',
}

export enum StorageTypeEnum {
  Local,
  Session,
  All
}

export enum PermissionEnum {
  User,
  Role,
  Permission,
  Oganization,
  All = 255,
}

export enum PermissionDetailEnum {
  Add,
  ViewOwner,
  ViewDetail,
  ViewList,
  EditOwner,
  Edit,
  DeleteOwner,
  Delete,
  All = 255,
}

export const BaseEnum = {
  RouterAppEnum,
  LocalStorageKeyEnum,
  PermissionEnum,
  PermissionDetailEnum,
  StorageTypeEnum
}