﻿# Changes API : How to subscribe to document changes?

Following methods allow you to subscribe to document changes:

- [ForDocument](../../client-api/changes/how-to-subscribe-to-document-changes#fordocument)
- [ForDocumentsInCollection](../../client-api/changes/how-to-subscribe-to-document-changes#fordocumentsincollection)
- [ForDocumentsOfType](../../client-api/changes/how-to-subscribe-to-document-changes#fordocumentsoftype)
- [ForDocumentsStartingWith](../../client-api/changes/how-to-subscribe-to-document-changes#fordocumentsstartingwith)
- [ForAllDocuments](../../client-api/changes/how-to-subscribe-to-document-changes#foralldocuments)

{PANEL:ForDocument}

Single document changes can be observed using `ForDocument` method.

### Syntax

{CODE document_changes_1@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **docId** | string | ID of a document for which notifications will be processed. |

| Return Value | |
| ------------- | ----- |
| IChangesObservable<[DocumentChange](../../client-api/changes/how-to-subscribe-to-document-changes#documentchange)> | Observable that allows to add subscriptions to notifications for given document. |

### Example

{CODE document_changes_2@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

{PANEL/}

{PANEL:ForDocumentsInCollection}

To observe all document changes in particular collection use `ForDocumentInCollection` method. This method filters documents by `@collection` metadata property value.

### Syntax

{CODE document_changes_3@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **collectionName** | string | Name of document collection for which notifications will be processed. |

| Return Value | |
| ------------- | ----- |
| IChangesObservable<[DocumentChange](../../client-api/changes/how-to-subscribe-to-document-changes#documentchange)> | Observable that allows to add subscriptions to notifications for given document collection name. |

{INFO Overload with `TEntity` type uses `Conventions.GetCollectionName` to get collection name. /}

### Example

{CODE document_changes_4@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

or

{CODE document_changes_5@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

{PANEL/}

{PANEL:ForDocumentsOfType}

To observe all document changes for given type use `ForDocumentsOfType` method. This method filters documents by `Raven-Clr-Type` metadata property value.

## Syntax

{CODE document_changes_6@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **typeName** or **type** | string or Type | Name of type or type for which notifications will be processed. If default conventions are used, the full type name without version information should be passed. See `Raven.Client.Util.ReflectionUtil.GetFullNameWithoutVersionInformation`. |

| Return Value | |
| ------------- | ----- |
| IChangesObservable<[DocumentChange](../../client-api/changes/how-to-subscribe-to-document-changes#documentchange)> | Observable that allows to add subscriptions to notifications for given document type name. |

{INFO Overloads with `TEntity` type or `Type` uses `Conventions.FindClrTypeName` to get type name. /}

## Example

{CODE document_changes_7@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

or 

{CODE document_changes_8@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

{PANEL/}

{PANEL:ForDocumentsStartingWith}

To observe all document changes for documents with ID that contains given prefix use `ForDocumentsStartingWith` method.

## Syntax

{CODE document_changes_9@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **docIdPrefix** | string | Document ID prefix for which notifications will be processed. |

| Return Value | |
| ------------- | ----- |
| IChangesObservable<[DocumentChange](../../client-api/changes/how-to-subscribe-to-document-changes#documentchange)> | Observable that allows to add subscriptions to notifications for given document ID prefix. |

## Example

{CODE document_changes_1_0@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

{PANEL/}

{PANEL:ForAllDocuments}

To observe all document changes use `ForAllDocuments` method.

## Syntax

{CODE document_changes_1_1@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

| Return Value | |
| ------------- | ----- |
| IChangesObservable<[DocumentChange](../../client-api/changes/how-to-subscribe-to-document-changes#documentchange)> | Observable that allows to add subscriptions to notifications for all documents. |

## Example

{CODE document_changes_1_2@ClientApi\Changes\HowToSubscribeToDocumentChanges.cs /}

{PANEL/}

{PANEL:DocumentChange}
### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **Type** | [DocumentChangeTypes](../../client-api/changes/how-to-subscribe-to-document-changes#documentchangetypes) | Document change type enum |
| **Id** | string | Document identifier |
| **CollectionName** | string | Document's collection name |
| **TypeName** | string | Type name |
| **ChangeVector** | string | Document's ChangeVector|

<hr />
{PANEL/}

{PANEL:DocumentChangeTypes}
# DocumentChangeTypes (enum flags)

### Members

| Name | Value |
| ---- | ----- |
| **None** | `0` |
| **Put** | `1` |
| **Delete** | `2` |
| **BulkInsertStarted** | `4` |
| **BulkInsertEnded** | `8` |
| **BulkInsertError** | `16` |
| **DeleteOnTombstoneReplication** | `32` |
| **Conflict** | `64` |
| **Common** | `Put & Delete` |
{PANEL/}

## Remarks

{INFO To get more method overloads, especially the ones supporting delegates, please add [Reactive Extensions Core](https://www.nuget.org/packages/System.Reactive.Core/) package to your project. /}

