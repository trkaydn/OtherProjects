import { Injectable } from '@angular/core';
import { Firestore, doc,collection,addDoc,deleteDoc,docData, collectionData,query, orderBy, updateDoc } from '@angular/fire/firestore';

export interface kayitBilgi{
  id?:string;
  ad?:string;
  ceptel?:string;
}


@Injectable({
  providedIn: 'root'
})
export class FireService {

  constructor(private firestore:Firestore) { }

  kayitListele()
  {
    const kayitSonuc = collection(this.firestore, 'kayitlar');
    return collectionData(kayitSonuc, {idField: 'id'});
  }

  yeniKayit(kayit:kayitBilgi)
  {
    const kayitSonuc = collection(this.firestore, 'kayitlar');
    return addDoc(kayitSonuc,kayit);
  }

  kayitGetir(id)
  {
    const kayitSonuc = doc(this.firestore, `kayitlar/${id}`);
    return docData(kayitSonuc, {idField: 'id'});
  }

  kayitSil(id)
  {
    const kayitSonuc = doc(this.firestore, `kayitlar/${id}`);
    return deleteDoc(kayitSonuc);
  }

  kayitGuncelle(kayit:kayitBilgi)
  {
    const kayitSonuc = doc(this.firestore, `kayitlar/${kayit.id}`);
    return updateDoc(kayitSonuc,{ad:kayit.ad, ceptel:kayit.ceptel});
  }

}
