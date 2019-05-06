import LoadableComponent from './../Loadable/index';

export const userRouter: any = [
  {
    path: '/user',
    name: 'user',
    title: 'User',
    component: LoadableComponent(() => import('src/components/Layout/UserLayout')),
    isLayout: true,
    showInMenu: false,
  },
  {
    path: '/user/login',
    name: 'login',
    title: 'LogIn',
    component: LoadableComponent(() => import('src/scenes/Login')),
    showInMenu: false,
  },
];

export const appRouters: any = [
  {
    path: '/',
    exact: true,
    name: 'home',
    permission: '',
    title: 'Home',
    icon: 'home',
    component: LoadableComponent(() => import('src/components/Layout/AppLayout')),
    isLayout: true,
    showInMenu: false,
  },
  {
    path: '/dashboard',
    name: 'dashboard',
    permission: '',
    title: 'Dashboard',
    icon: 'home',
    showInMenu: true,
    component: LoadableComponent(() => import('src/scenes/Dashboard')),
  },
  {
    path: '/logout',
    permission: '',
    title: 'Logout',
    name: 'logout',
    icon: 'info-circle',
    showInMenu: false,
    component: LoadableComponent(() => import('src/components/Logout')),
  },
  {
    path: '/exception',
    permission: '',
    title: 'exception',
    name: 'exception',
    icon: 'info-circle',
    showInMenu: false,
    component: LoadableComponent(() => import('src/scenes/Exception')),
  },
  {
    path: '/planestudios',
    permission: '',
    title: 'Plan de Estudios',
    name: 'planestudios',
    icon: 'book',
    showInMenu: true,
    component: LoadableComponent(() => import('src/scenes/PlanEstudios')),
  },
  {
    path: '/alumnos',
    permission: '',
    title: 'Alumnos',
    name: 'alumnos',
    icon: 'user',
    showInMenu: true,
    component: LoadableComponent(() => import('src/scenes/Alumnos')),
  },
  {
    path: '/grupos',
    permission: '',
    title: 'Grupos',
    name: 'grupos',
    icon: 'appstore',
    showInMenu: true,
    component: LoadableComponent(() => import('src/scenes/Grupos')),
  },
];

export const routers = [...userRouter, ...appRouters];
