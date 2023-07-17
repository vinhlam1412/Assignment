import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eConfigurationRouteNames } from '../enums/route-names';

export const HQTASKS_HQTASK_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/configuration/hqtasks',
        parentName: eConfigurationRouteNames.Configuration,
        name: 'Configuration::Menu:HQTasks',
        layout: eLayoutType.application,
        requiredPolicy: 'Configuration.HQTasks',
      },
    ]);
  };
}
