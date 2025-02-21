
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { DiagnosticService, DetectorMetaData, DetectorType } from 'diagnostic-data';
import { Observable } from 'rxjs';
import { ResourceService } from './resource.service';

@Injectable()
export class SupportTopicService {

  protected detectorTask: Observable<DetectorMetaData[]>;

  constructor(protected _diagnosticService: DiagnosticService, protected _webSiteService: ResourceService) {
    this.detectorTask = this._diagnosticService.getDetectors();
  }

  getPathForSupportTopic(supportTopicId: string, pesId: string): Observable<string> {
    return this.detectorTask.pipe(map(detectors => {
      let detectorPath = '';

      if (detectors) {
        const matchingDetector = detectors.find(detector =>
          detector.supportTopicList &&
          detector.supportTopicList.findIndex(supportTopic => supportTopic.id === supportTopicId) >= 0);

        if (matchingDetector) {
          if (matchingDetector.type === DetectorType.Detector) {
            detectorPath = `/detectors/${matchingDetector.id}`;
          } else if (matchingDetector.type === DetectorType.Analysis) {
            detectorPath = `/analysis/${matchingDetector.id}`;
          }
        }
      }

      return detectorPath;
    }));
  }
}
