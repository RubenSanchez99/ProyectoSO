import RoleStore from './roleStore';
import TenantStore from './tenantStore';
import UserStore from './userStore';
import SessionStore from './sessionStore';
import AuthenticationStore from './authenticationStore';
import AccountStore from './accountStore';
import PlanEstudiosStore from './planEstudiosStore';
import AlumnoStore from './alumnoStore';
import GrupoStore from './grupoStore';

export default function initializeStores() {
  return {
    authenticationStore: new AuthenticationStore(),
    roleStore: new RoleStore(),
    tenantStore: new TenantStore(),
    userStore: new UserStore(),
    sessionStore: new SessionStore(),
    accountStore: new AccountStore(),
    planEstudiosStore: new PlanEstudiosStore(),
    alumnoStore: new AlumnoStore(),
    grupoStore: new GrupoStore(),
  };
}
